using Microsoft.AspNetCore.Mvc;
namespace InternetCafe.Controllers;
public class ManagerController : Controller {
    [HttpGet]
    public IActionResult Home() {
        return View();
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