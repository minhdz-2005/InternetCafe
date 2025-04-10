using InternetCafe.Data;
using InternetCafe.Models;

namespace InternetCafe.Services;
public class ComputerSevice {
    private readonly InternetCafeContext _context;
    public ComputerSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (Computer c) {
        _context.Computer.Add (c);
        _context.SaveChanges();
    }
    public void Update (int id, Computer c) {
        var existing = _context.Computer.Find(id);
        if (existing != null) {
            existing.Name = c.Name;
            existing.Cost = c.Cost;
            existing.Status = c.Status;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.Computer.Find(id);
        if(existing != null) {
            _context.Computer.Remove(existing);
            _context.SaveChanges();
        }
    }
    public Computer? GetById (int id) {
        Computer c = new Computer();
        var existing = _context.Computer.Find(id);
        if(existing != null) {
            c.Id = existing.Id;
            c.Name = existing.Name;
            c.Cost = existing.Cost;
            c.Status = existing.Status;
        }

        return c;
    }
    public List<Computer> GetAll () {
        return _context.Computer.ToList();
    }
}