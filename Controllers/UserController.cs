using Microsoft.AspNetCore.Mvc;

namespace InternetCafe.Controllers;
public class UserCOntroller : Controller {
    
    [HttpGet]
    public IActionResult Home () {
        return View();
    }
    [HttpGet]
    public IActionResult ListComputer () {
        return View();
    }
    [HttpGet]
    public IActionResult Deposit () {
        return View();
    }
    [HttpGet]
    public IActionResult HomeUsing () {
        return View();
    }
    [HttpGet]
    public IActionResult HomeUsed () {
        return View();
    }
}