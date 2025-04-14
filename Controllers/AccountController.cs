using Microsoft.AspNetCore.Mvc;
using InternetCafe.Models;
using InternetCafe.Data;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
namespace InternetCafe.Controllers;



public class AccountController : Controller {
    private readonly InternetCafeContext _context;
    public AccountController(InternetCafeContext context) {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Login() {
        return View(new Account());
    }
    [HttpPost] 
    public IActionResult Login(Account a) {
        if (ModelState.IsValid) {
            var acc = _context.Account.FirstOrDefault(x => x.Username == a.Username);

            if (acc != null && a.Password == acc.Password) {
                if (acc.Role == "Manager") {
                    return RedirectToAction ("Home", "Manager");
                }
                else {
                    return RedirectToAction ("Home", "User");
                }
            }
            else ModelState.AddModelError("", "Invalid username or password");
        }
        return View(a);
    }


    [HttpGet]
    public IActionResult Register() {
        return View();
    }
    [HttpPost]
    public IActionResult Register (User u, string password) {

        Console.WriteLine($"Name : {u.Name}");
        Console.WriteLine($"PhoneNumber : {u.PhoneNumber}");
        Console.WriteLine($"Username : {u.Username}");
        Console.WriteLine($"Password : {password}");
        if (string.IsNullOrEmpty(password) || password.Length < 8) ModelState.AddModelError("", "The password must be at least 8 characters");
        
        if (ModelState.IsValid) {
            Console.WriteLine("Dung roi");
            var existing = _context.Account.FirstOrDefault(x => x.Username == u.Username);

            if (existing == null) {
                Console.WriteLine("ko ton tai");
                _context.Account.Add(new Account(u.Username, password, "User"));
                _context.User.Add(new Models.User(u.Name, u.PhoneNumber, 0, u.Username));
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Register successful, please login !";
                return RedirectToAction("Login", "Account");
            }
            else ModelState.AddModelError("", "The username is already exist!");
        }
        return View();
    }
}