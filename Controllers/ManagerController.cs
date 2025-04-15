using InternetCafe.Data;
using InternetCafe.Models;
using Microsoft.AspNetCore.Mvc;
namespace InternetCafe.Controllers;
public class ManagerController : Controller {
    private readonly InternetCafeContext _context;
    public ManagerController (InternetCafeContext context) {
        _context = context;
    }
    [HttpGet]
    public IActionResult Home() {
        UsingViewModel usingModel = new UsingViewModel();
        

        return View(usingModel);
    }
    [HttpGet]
    public IActionResult ListComputer() {
        return View();
    }
    [HttpGet]
    public IActionResult RevenueByComputer() {
        return View();
    }
    [HttpGet]
    public IActionResult RevenueByDate() {
        return View();
    }
    [HttpGet]
    public IActionResult AddComputer () {
        return View();
    }
    [HttpGet]
    public IActionResult UpdateComputer () {
        return View();
    }
    [HttpGet]
    public IActionResult DeleteComputer () {
        return View();
    }
}