namespace InternetCafe.Models;
public class UsedViewModel {
    public int Id { get; set; }
    public string ComputerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime = DateTime.Now;
    public decimal Cost { get; set; }
    
    public UsedViewModel() {}
    public UsedViewModel (string computerName, DateTime startTime, DateTime endTime, decimal cost) {
        ComputerName = computerName;
        StartTime = startTime;
        EndTime = endTime;
        Cost = cost;   
    }
}