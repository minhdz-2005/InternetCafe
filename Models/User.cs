using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace InternetCafe.Models;
public class User {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }
    [Precision(18,2)]
    public decimal Money { get; set; }
    public string? Username { get; set; }

    public User() {}
    public User (string name, string phoneNumber, decimal money , string username) {
        Name = name;
        PhoneNumber = phoneNumber;
        Money = money;
        Username = username;
    }
}