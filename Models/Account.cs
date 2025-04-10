using System.ComponentModel.DataAnnotations;
namespace InternetCafe.Models;
public class Account {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Username { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Password { get; set; }
    [Required]
    public string? Role { get; set; }
}