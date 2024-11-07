using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.ModelsEF;

public class CartProductEf
{
    //one to many - один продукт в корзине принадлежит одному аккаунту, один аккаунт может иметь много продуктов в корзине
    [ForeignKey("Account")]
    public int AccountId { get; init; }
    public AccountEf? Account { get; init; }
    
    //one to many - один продукт в корзине принадлежит одному продукту, один продукт может быть в корзине у многих аккаунтов
    [ForeignKey("Product")]
    public int ProductId { get; init; }
    public ProductEf? Product { get; init; }
    
    public uint Quantity { get; set; }
}