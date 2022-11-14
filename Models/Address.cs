namespace TechnicalTask.Models;

public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string FullAddress { get; set; }
    public int PostCode { get; set; }
}