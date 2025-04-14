using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace InternetCafe.Models;
public class User {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
    public string PhoneNumber { get; set; } = string.Empty;
    [Precision(18,2)]
    public decimal Money { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(8, ErrorMessage = "The username must be at least 8 characters")]
    public string Username { get; set; } = string.Empty;

    public User() {}
    public User (string name, string phoneNumber, decimal money , string username) {
        Name = name;
        PhoneNumber = phoneNumber;
        Money = money;
        Username = username;
    }
}