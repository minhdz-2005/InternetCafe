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

        var us = _context.ActiveUserComputer.FirstOrDefault(x => x.ComputerId == i);
        if(us != null) usingModel = us;

        if(i == 0 && id == null) {
            Console.WriteLine("if 1");
            return View(null);
        }

        if(i == 0 && id != null) {
            Console.WriteLine("if 2");
            HttpContext.Session.SetInt32("useState", (int)id);
            HttpContext.Session.SetInt32("IsUsing", 1);

            var c = _context.Computer.FirstOrDefault(x => x.Id == id);

            int? userId = HttpContext.Session.GetInt32("UserId");

            var u = _context.User.FirstOrDefault(x => x.Id == userId);

            if (c != null && c.Name != null && u != null) {
                Console.WriteLine("if 3");
                usingModel.UserId = u.Id;
                usingModel.NameUser = u.Name;
                usingModel.ComputerId = c.Id;
                usingModel.ComputerName = c.Name;
                usingModel.StartTime = DateTime.Now;

                c.Status = true;

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
            c.Status = false;
            HttpContext.Session.SetInt32("IsUsing", 0);

            usedModel.ComputerName = c.Name;
            usedModel.StartTime = dateTime;
            usedModel.EndTime = DateTime.Now;
            decimal timeEnd = usedModel.EndTime.Hour + (decimal)usedModel.EndTime.Minute/60 + (decimal)usedModel.EndTime.Second/3600;
            decimal timeStart = dateTime.Hour + (decimal)dateTime.Minute/60 + (decimal)dateTime.Second/3600;
            usedModel.Cost = c.Cost * (timeEnd - timeStart);

            int? userId = HttpContext.Session.GetInt32("UserId");

            var u = _context.User.FirstOrDefault(x => x.Id == userId);
            if(u != null) {
                u.Money -= usedModel.Cost;
                _context.SaveChanges();

                HttpContext.Session.SetString("Money", u.Money.ToString("0.00"));
            }
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