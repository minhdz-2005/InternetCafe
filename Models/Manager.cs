using System.ComponentModel.DataAnnotations;
namespace InternetCafe.Models;
public class Manager {
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Username { get; set; }
    
    public Manager() {}
    public Manager (string username) {
        Username = username;
    }
}