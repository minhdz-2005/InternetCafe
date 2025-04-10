using InternetCafe.Data;
using InternetCafe.Models;

namespace InternetCafe.Services;
public class ManagerSevice {
    private readonly InternetCafeContext _context;
    public ManagerSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (Manager a) {
        _context.Manager.Add (a);
        _context.SaveChanges();
    }
    public void Update (int id, Manager a) {
        var existing = _context.Manager.Find(id);
        if (existing != null) {
            existing.Username = a.Username;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.Manager.Find(id);
        if(existing != null) {
            _context.Manager.Remove(existing);
            _context.SaveChanges();
        }
    }
    public Manager? GetById (int id) {
        Manager a = new Manager();
        var existing = _context.Manager.Find(id);
        if(existing != null) {
            a.Id = existing.Id;
            a.Username = existing.Username;
        }

        return a;
    }
    public List<Manager> GetAll () {
        return _context.Manager.ToList();
    }
}