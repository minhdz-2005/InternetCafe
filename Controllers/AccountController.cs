using Microsoft.AspNetCore.Mvc;
using InternetCafe.Models;
using InternetCafe.Data;
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
                HttpContext.Session.SetString("Username", acc.Username);
                if (acc.Role == "User") {
                    var u = _context.User.FirstOrDefault(x => x.Username == a.Username);
                    if(u != null) {
                        HttpContext.Session.SetInt32("UserId", u.Id);
                        HttpContext.Session.SetString("Money", u.Money.ToString("0.00"));
                        HttpContext.Session.SetString("Name", u.Name);
                        HttpContext.Session.SetInt32("IsUsing", 0);
                    }
                }
                if (acc.Role == "Manager") {                    
                    return RedirectToAction ("Home", "Manager");
                }
                else {
                    return RedirectToAction ("Home", "User");
                }
            }
            else ModelState.AddModelError("", "Invalid username or password !");
        }
        return View(a);
    }
    [HttpPost]
    public IActionResult Register (Account a, string name, string phoneNumber, string confirmPass) {
        if (string.IsNullOrEmpty(confirmPass) || confirmPass != a.Password) ModelState.AddModelError("", "The password and comfirm password must be the same");
        if (ModelState.IsValid) {
            a.Role = "User";
            var existing = _context.Account.FirstOrDefault(x => x.Username == a.Username);
            if (existing == null) {
                _context.Account.Add(a);
                _context.User.Add(new Models.User(name, phoneNumber, 0,  a.Username));
                _context.SaveChanges();
                
                TempData["SuccessMessage"] = "Register successful, please login !";
                return RedirectToAction("Login", "Account");
            }
            else ModelState.AddModelError("", "The username is already exist!");
        }
        ViewBag.ShowRegisterForm = true;
        return View("Login", a);
    }
}