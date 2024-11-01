using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.ModelsEF;

public class ProductEf
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public string? Category { get; set; }
    public byte[]? Photo { get; set; }
}