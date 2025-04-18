using InternetCafe.Data;
using InternetCafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace InternetCafe.Controllers;
[Authorize]
public class ManagerController : Controller {
    private readonly InternetCafeContext _context;
    public ManagerController (InternetCafeContext context) {
        _context = context;
    }
    [HttpGet]
    public IActionResult Home() {
        List<UsingViewModel> usingModel = _context.ActiveUserComputer.ToList();

        return View(usingModel);
    }
    [HttpGet]
    public IActionResult ListComputer() {
        List<Computer> computerList = _context.Computer.ToList();
        return View(computerList);
    }
    [HttpGet]
    public IActionResult RevenueByComputer() {
        List<Computer> list = _context.Computer.ToList();
        return View(list);
    }
    [HttpGet]
    public IActionResult RevenueByDate() {
        List<UsedInfo> list = _context.UsedInfo.ToList();
        List<UsedInfo> rev = new List<UsedInfo>();
        foreach (var item in list) {
            foreach (var r in rev) {
                if (item.Date.Day == r.Date.Day && item.Date.Month == r.Date.Month && item.Date.Year == r.Date.Year) {
                    r.Amount += item.Amount;
                }
                else {
                    rev.Add(item);
                }
            }
            if (rev.IsNullOrEmpty()) rev.Add(item);
        }
        return View(rev);
    }
    [HttpGet]
    public IActionResult AddComputer () {
        return View();
    }
    [HttpPost]
    public IActionResult AddComputer (string name, decimal cost) {
        _context.Computer.Add(new Computer(name, cost));
        _context.SaveChanges();
        return RedirectToAction("ListComputer", "Manager");
    }
    [HttpGet]
    public IActionResult UpdateComputer (int id) {
        var c = _context.Computer.FirstOrDefault(x => x.Id == id);
        return View(c);
    }
    [HttpPost]
    public IActionResult ConfirmUpdateComputer (int id, string name, decimal cost) {
        var existing = _context.Computer.FirstOrDefault(x => x.Id == id);
        if (existing != null) {
            existing.Name = name;
            existing.Cost = cost;

            _context.SaveChanges();
        }

        return RedirectToAction("ListComputer", "Manager");
    }
    [HttpGet]
    public IActionResult DeleteComputer (int id) {
        var c = _context.Computer.FirstOrDefault(x => x.Id == id);
        return View(c);
    }
    [HttpPost]
    public IActionResult ConfirmDeleteComputer (int id) {
        var c = _context.Computer.FirstOrDefault(x => x.Id == id);
        if (c != null) {
            _context.Computer.Remove(c);
            _context.SaveChanges();
        }
        return RedirectToAction("ListComputer", "Manager");
    }
}