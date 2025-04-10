using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace InternetCafe.Models;
public class UsedInfo {
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Computer")]
    public int ComputerId { get; set; }
    public TimeSpan UsedTime { get; set; }
    public DateTime Date { get; set; }
    [Precision(18,2)]
    public decimal Amount { get; set; }

    public UsedInfo() {}
    public UsedInfo (int userId, int computerId, TimeSpan time, DateTime date) {
        UserId = userId;
        ComputerId = computerId;
        UsedTime = time;
        Date = date;
    }
}