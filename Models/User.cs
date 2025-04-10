using System.ComponentModel.DataAnnotations;
namespace InternetCafe.Models;
public class User {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? PhoneNumber { get; set; }
    public decimal Money { get; set; }
    public string? Username { get; set; }
}