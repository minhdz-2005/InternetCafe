using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternetCafe.Models;
public class UsedInfo {
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Computer")]
    public int ComputerId { get; set; }
    public TimeSpan UsedTime { get; set; }
}