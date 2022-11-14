namespace TechnicalTask.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int AddressId { get; set; }
    public int PositionId { get; set; }
    public DateTime SigningTimeUtc { get; set; }
    public DateTime? LeavingTimeUtc { get; set; }
    public bool IsActive { get; set; }
}