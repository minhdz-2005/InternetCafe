
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetCafe.Models;

public class UsingViewModel {
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public string NameUser { get; set; } = string.Empty;
    [ForeignKey("Computer")]
    public int ComputerId { get; set; }
    public string ComputerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    
    public UsingViewModel() {}
    public UsingViewModel(int userId, string nameUser, int computerId, string computerName, DateTime startTime) {
        UserId = userId;
        NameUser = nameUser;
        ComputerId = computerId;
        ComputerName = computerName;
        StartTime = startTime;
    }
}