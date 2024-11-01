namespace Store.DTO;

public record CartItem(byte[] Photo = null!, string Name = "", decimal Price = 0m, int Quantity = 0, int Id = 0);
