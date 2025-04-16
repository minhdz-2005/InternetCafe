using System.Data.Common;
using InternetCafe.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetCafe.Data;
public class InternetCafeContext : DbContext {
    public InternetCafeContext (DbContextOptions<InternetCafeContext> option) : base (option) { }

    public DbSet<Account> Account { get; set; }
    public DbSet<Computer> Computer { get; set; }
    public DbSet<Manager> Manager { get; set; }
    public DbSet<UsedInfo> UsedInfo { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UsingViewModel> ActiveUserComputer { get; set; }

    protected override void OnModelCreating (ModelBuilder model) {
        model.Entity<Account>().HasIndex(a => a.Username).IsUnique();
    }
}