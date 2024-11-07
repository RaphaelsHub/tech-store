using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.ModelsEF;

public class OrderProductEf
{
    //one to many - один продукт в заказе принадлежит одному юзеру, один юзер может содержать много продуктов в заказе
    [ForeignKey("Account")]
    public int AccountId { get; init; }
    public AccountEf? Account { get; init; }
    
    //one to many - один продукт в заказе принадлежит одному заказу, один заказ может содержать много продуктов
    [ForeignKey("Product")]
    public int ProductId { get; init; }
    public ProductEf? Product { get; init; }
    
    public uint Quantity { get; init; }
}