using Microsoft.AspNetCore.Mvc;
using InternetCafe.Models;
using InternetCafe.Data;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Services;
using Microsoft.AspNetCore.Identity;
namespace InternetCafe.Controllers;



public class AccountController : Controller {
    private readonly InternetCafeContext _context;
    public AccountController(InternetCafeContext context) {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Login() {
        return View();
    }

    // [HttpPost] 
    // public IActionResult Login(Account a) {
    //     if (ModelState.IsValid) {
    //         //
    //         var acc = _context.Account.FirstOrDefault(x => x.Username == a.Username);

    //         if(acc != null) {
    //             var passwordHasher = new PasswordHasher<Account>();
    //             var result = passwordHasher.VerifyHashedPassword(null!, acc.Password!, a.Password!);

    //             if (result == PasswordVerificationResult.Success) {
    //                 if (a.Role == "Manager") return RedirectToAction ("Home", "Manager");
    //                 else return RedirectToAction ("Home", "User");
    //             }
    //             ModelState.AddModelError("", "Password incorrect, please try again!");
    //         }
    //         else ModelState.AddModelError("", "The account not exist");
            
    //     }
    //     return View();
    // }
    [HttpGet]
    public IActionResult Register() {
        return View();
    }
    
}