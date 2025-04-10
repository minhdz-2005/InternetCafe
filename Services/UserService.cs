using InternetCafe.Data;
using InternetCafe.Models;

namespace InternetCafe.Services;
public class UserSevice {
    private readonly InternetCafeContext _context;
    public UserSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (User a) {
        _context.User.Add (a);
        _context.SaveChanges();
    }
    public void Update (int id, User a) {
        var existing = _context.User.Find(id);
        if (existing != null) {
            existing.Name = a.Name;
            existing.PhoneNumber = a.PhoneNumber;
            existing.Money = a.Money;
            existing.Username = a.Username;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.User.Find(id);
        if(existing != null) {
            _context.User.Remove(existing);
            _context.SaveChanges();
        }
    }
    public User? GetById (int id) {
        User a = new User();
        var existing = _context.User.Find(id);
        if(existing != null) {
            a.Id = existing.Id;
            a.Name = existing.Name;
            a.PhoneNumber = existing.PhoneNumber;
            a.Money = existing.Money;
            a.Username = existing.Username;
        }

        return a;
    }
    public List<User> GetAll () {
        return _context.User.ToList();
    }
}