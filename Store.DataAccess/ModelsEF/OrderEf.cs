using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Store.DataAccess.ModelsEF;

public class OrderEf
{
    [Key]
    public int Id { get; set; } 

    //one to many, один заказ принадлежит одному аккаунту, один аккаунт может иметь много заказов
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public AccountEf? Account { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? Comment { get; set; }
    
    //many to many, один заказ может содержать много продуктов, один продукт может быть в многих заказах
    public List<OrderProductEf> Products { get; set; } = new();
}
