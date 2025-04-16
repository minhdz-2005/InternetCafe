using InternetCafe.Data;
using InternetCafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetCafe.Controllers;
public class UserController : Controller {
    private readonly InternetCafeContext _context;
    public UserController (InternetCafeContext context) {
        _context = context;
    }
    [HttpGet]
    public IActionResult Home (int? id) {
        UsingViewModel usingModel = new UsingViewModel();
        int? i = HttpContext.Session.GetInt32("useState");
        if (i == null) i = 0;
        var us = _context.ActiveUserComputer.FirstOrDefault(x => x.Id == i);
        if(us != null) usingModel = us;
        if(i == 0 && id == null) {
            return View(null);
        }
        if(i == 0 && id != null) {
            HttpContext.Session.SetInt32("useState", (int)id);
            var c = _context.Computer.FirstOrDefault(x => x.Id == i);
            int? userId = HttpContext.Session.GetInt32("UserId");
            var u = _context.User.FirstOrDefault(x => x.Id == userId);
            if (c != null && c.Name != null && u != null) {
                usingModel.UserId = u.Id;
                usingModel.NameUser = u.Name;
                usingModel.ComputerId = c.Id;
                usingModel.ComputerName = c.Name;
                usingModel.StartTime = DateTime.Now;

                _context.ActiveUserComputer.Add(usingModel);
                _context.SaveChanges();
                return View(usingModel);
            }
        }
        
        return View(usingModel);
    }
    [HttpGet]
    public IActionResult HomeUsed(int computerId, DateTime dateTime) {
        Console.WriteLine($"Comid: {computerId}, Date: {dateTime}");
        HttpContext.Session.SetInt32("useState", 0);
        var usingModel = _context.ActiveUserComputer.FirstOrDefault(x => x.ComputerId == computerId);
        if (usingModel != null) {
            _context.ActiveUserComputer.Remove(usingModel);
            _context.SaveChanges();
        }

        UsedViewModel usedModel = new UsedViewModel();
        var c = _context.Computer.FirstOrDefault(x => x.Id == computerId);
        if(c != null && c.Name != null) {
            decimal cost = c.Cost * dateTime.Hour;
            usedModel.ComputerName = c.Name;
            usedModel.StartTime = dateTime;
            usedModel.EndTime = DateTime.Now;
            usedModel.Cost = cost;
        }
        return View(usedModel);
    }
    [HttpGet]
    public IActionResult ListComputer () {
        List<Computer> list = _context.Computer.ToList ();
        return View(list);
    }
    [HttpGet]
    public IActionResult Deposit () {
        return View();
    }
    [HttpPost]
    public IActionResult Deposit (decimal amount) {
        string? username = HttpContext.Session.GetString("Username");
        
        var u = _context.User.FirstOrDefault(x => x.Username == username);
        if (u != null) {
            u.Money += amount;
            HttpContext.Session.SetString("Money", u.Money.ToString());

            _context.SaveChanges();
        }
        return RedirectToAction("ListComputer", "User");
    }
    
}