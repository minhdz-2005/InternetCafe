
namespace InternetCafe.Models;

public class UsingViewModel {
    public List<User> Users { get; set; } = new();
    public List<Computer> Computers { get; set; } = new();
    public UsingViewModel() {}
}