using System.ComponentModel.DataAnnotations;

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
    
    //many to many, один аккаунт может иметь много продуктов в корзине, один продукт может быть в корзине у многих аккаунтов
    public List<CartProductEf> CartProducts { get; init; } = new();
    
    
    //one to many, один аккаунт может иметь много заказов, один заказ принадлежит одному аккаунту
    public List<OrderEf> Orders { get; init; } = new();
    

}