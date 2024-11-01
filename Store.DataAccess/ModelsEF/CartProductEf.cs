using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.ModelsEF;

public class CartProductEf
{
    //one to many - один продукт в корзине принадлежит одному аккаунту, один аккаунт может иметь много продуктов в корзине
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public AccountEf? Account { get; set; }
    
    //one to many - один продукт в корзине принадлежит одному продукту, один продукт может быть в корзине у многих аккаунтов
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductEf? Product { get; set; }
    
    public uint Quantity { get; set; }
}