namespace Store.DataAccess.Entities;

public class AccountEf
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Number { get; set; }
    public string? PasswordHash { get; set; }
}