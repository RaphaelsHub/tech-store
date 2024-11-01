using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.ModelsEF;

public class OrderProductEf
{
    //one to meny - один продукт в заказе принадлежит одному юзеру, один юзер может содержать много продуктов в заказе
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public AccountEf? Account { get; set; }
    
    //one to many - один продукт в заказе принадлежит одному заказу, один заказ может содержать много продуктов
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public ProductEf? Product { get; set; }
    
    public uint Quantity { get; set; }
}