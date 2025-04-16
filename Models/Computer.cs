using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace InternetCafe.Models;
public class Computer {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Precision(10,2)]
    public decimal Cost { get; set; }
    [DefaultValue(false)]
    public bool Status { get; set; } 
    [Precision(18,2)]
    public decimal Revenue { get; set; }
    public Computer() {}
    public Computer (string name, decimal cost) {
        Name = name;
        Cost = cost;
    }
}