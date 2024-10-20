namespace Store.DTO;

public record CartDto(IEnumerable<CartItem> Products)
{
    public decimal TotalPrice => Products.Sum(p => p.Price * p.Quantity);
    public decimal DeliveryPrice => 10; // Need to be calculated, but for now it's a constant
}