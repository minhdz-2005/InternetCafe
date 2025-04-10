using InternetCafe.Data;
using InternetCafe.Models;

namespace InternetCafe.Services;
public class UsedInfoSevice {
    private readonly InternetCafeContext _context;
    public UsedInfoSevice (InternetCafeContext context) {
        _context = context;
    }

    public void Add (UsedInfo a) {
        var c = _context.Computer.Find(a.ComputerId);

        decimal h = (decimal) a.UsedTime.Hours;
        decimal m = (decimal) a.UsedTime.Minutes;
        decimal s = (decimal) a.UsedTime.Seconds;

        if(c != null) a.Amount = c.Cost * (h + m/60 + s/60);

        _context.UsedInfo.Add (a);
        _context.SaveChanges();
    }
    public void Update (int id, UsedInfo a) {
        var existing = _context.UsedInfo.Find(id);
        if (existing != null) {
            existing.UserId = a.UserId;
            existing.ComputerId = a.ComputerId;
            existing.UsedTime = a.UsedTime;
            existing.Date = a.Date;
            
            _context.SaveChanges();
        }
    }
    public void Delete (int id) {
        var existing = _context.UsedInfo.Find(id);
        if(existing != null) {
            _context.UsedInfo.Remove(existing);
            _context.SaveChanges();
        }
    }
    public UsedInfo? GetById (int id) {
        UsedInfo a = new UsedInfo();
        var existing = _context.UsedInfo.Find(id);
        if(existing != null) {
            a.Id = existing.Id;
            a.UserId = existing.UserId;
            a.ComputerId = existing.ComputerId;
            a.UsedTime = existing.UsedTime;
            a.Date = existing.Date;
        }

        return a;
    }
    public List<UsedInfo> GetAll () {
        return _context.UsedInfo.ToList();
    }
}