namespace Store.DTO;

public record CartItem(byte[] Photo, string Name, decimal Price, int Quantity, int Id);