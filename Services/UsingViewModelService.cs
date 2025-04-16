using InternetCafe.Data;
using InternetCafe.Models;

namespace InternetCafe.Services;
public class UsingViewModelSevice {
    private readonly InternetCafeContext _context;
    public UsingViewModelSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (UsingViewModel a) {
        _context.ActiveUserComputer.Add (a);
        _context.SaveChanges();
    }
    public void Update (int id, UsingViewModel a) {
        var existing = _context.ActiveUserComputer.Find(id);
        if (existing != null) {
            existing.ComputerId = a.ComputerId;
            existing.ComputerName = a.ComputerName;
            existing.UserId = a.UserId;
            existing.NameUser = a.NameUser;
            existing.StartTime = a.StartTime;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.ActiveUserComputer.Find(id);
        if(existing != null) {
            _context.ActiveUserComputer.Remove(existing);
            _context.SaveChanges();
        }
    }
    public UsingViewModel? GetById (int id) {
        UsingViewModel a = new UsingViewModel();
        var existing = _context.ActiveUserComputer.Find(id);
        if(existing != null) {
            a.Id = existing.Id;
            a.ComputerId = existing.ComputerId;
            a.ComputerName = existing.ComputerName;
            a.UserId = existing.UserId;
            a.NameUser = existing.NameUser;
        }

        return a;
    }
    public List<UsingViewModel> GetAll () {
        return _context.ActiveUserComputer.ToList();
    }
}