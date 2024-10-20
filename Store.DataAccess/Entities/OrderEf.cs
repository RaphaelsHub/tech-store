namespace Store.DataAccess.Entities;

public class OrderEf
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? Comment { get; set; }
    public List<ProductEf> Products { get; set; } = new();
}