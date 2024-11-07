using System.ComponentModel.DataAnnotations;
// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength

namespace Store.DataAccess.ModelsEF;

public class AccountEf
{
    [Key]
    public int Id { get; init; }
    public int RoleId { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Number { get; init; }
    public string? PasswordHash { get; init; }
    
    public List<CartProductEf> CartProducts { get; init; } = new();
    public List<OrderEf> Orders { get; init; } = new();
}