using listOfProducts = System.Collections.Generic.List<Store.DataAccess.ModelsEF.CartProductEf>;
namespace Store.DataAccess.Interfaces;

public interface ICartRepository
{
    Task<bool> AddProductAsync(uint accountId,  uint productId, uint quantity);
    Task<bool> RemoveProductAsync(uint accountId, uint productId, uint quantity);
    Task<listOfProducts?> GetCartProductsAsync(uint accountId);
}