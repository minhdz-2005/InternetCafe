using InternetCafe.Data;
using InternetCafe.Models;
using Microsoft.AspNetCore.Identity;

namespace InternetCafe.Services;
public class AccountSevice {
    private readonly InternetCafeContext _context;
    public AccountSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (Account a) {
        var passwordHasher = new PasswordHasher<Account>();
        var acc = new Account {
            Username = a.Username,
            Password = passwordHasher.HashPassword(null!, a.Password!)
        };

        _context.Account.Add (a);
        _context.SaveChanges();
    }
    public void Update (int id, Account a) {
        var existing = _context.Account.Find(id);
        if (existing != null) {
            existing.Username = a.Username;
            existing.Password = a.Password;
            existing.Role = a.Role;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.Account.Find(id);
        if(existing != null) {
            _context.Account.Remove(existing);
            _context.SaveChanges();
        }
    }
    public Account? GetById (int id) {
        Account a = new Account();
        var existing = _context.Account.Find(id);
        if(existing != null) {
            a.Id = existing.Id;
            a.Username = existing.Username;
            a.Password = existing.Password;
            a.Role = existing.Role;
        }

        return a;
    }
    public List<Account> GetAll () {
        return _context.Account.ToList();
    }


    public bool IsExist (Account a) {
        var existing = _context.Account.Find(a);
        if(existing != null) return true;
        return false;
    }
}