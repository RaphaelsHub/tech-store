using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;

namespace Store.DataAccess.Repository;

public class CartsRepository(
    StoreDbContext db,
    IRepository<ProductEf> productsRepository,
    IRepository<AccountEf> accountsRepository,
    IRepository<OrderEf> ordersRepository)
    : ICartRepository
{
    public async Task<bool> AddProductAsync(uint accountId, uint productId, uint quantity)
    {
        var trackedProduct = await productsRepository.GetAsync(productId);
        if (trackedProduct == null) return false;

        var account = await db.Accounts
            .Include(accountEf => accountEf.CartProducts)
            .FirstOrDefaultAsync(x => x.Id == (int)accountId);
        if (account == null || trackedProduct.Quantity < quantity) return false;

        trackedProduct.Quantity -= quantity;
        await productsRepository.UpdateAsync(trackedProduct);
        
        var productEfCart = account.CartProducts.FirstOrDefault(x=>x.ProductId == (int)productId);

        if (productEfCart == null)
        {
            var tmp = new CartProductEf(){AccountId = (int)accountId, ProductId = (int)productId, Quantity = quantity};
            account.CartProducts.Add(tmp);
        }
        else
            productEfCart.Quantity += quantity;

        db.Accounts.Update(account);
        await db.SaveChangesAsync();
        return true;
    }


    public async Task<bool> RemoveProductAsync(uint accountId, uint productId, uint quantity)
    {
        //Проверяем есть ли такой продукт в приниципе с таким id
        var trackedProduct = await productsRepository.GetAsync(productId);
        if (trackedProduct == null) return false;

        //Проверяем есть ли такой пользователь с таким id
        var user = await db.Accounts.Include(x => x.CartProducts).FirstOrDefaultAsync(x => x.Id == (int)accountId);
        if (user == null) return false;

        //Получаем продукт в корзине пользователя через id продукта
        var cartProduct = user.CartProducts.FirstOrDefault(x => x.ProductId == (int)productId);

        //Если продукт в корзине есть и его количество больше или равно запрашиваемому количеству, то удаляем его из корзины
        if (cartProduct != null && quantity >= cartProduct.Quantity)
            user.CartProducts.Remove(cartProduct);
        else if (cartProduct != null && quantity < cartProduct.Quantity)
            cartProduct.Quantity -= quantity;
        else
            return false;
        
        trackedProduct.Quantity += quantity;
        db.Products.Update(trackedProduct);
        db.Accounts.Update(user);

        await db.SaveChangesAsync();
        return true;
    }

    public Task<List<CartProductEf>?> GetCartProductsAsync(uint accountId)
    {
        var account = db.Accounts.Include(accountEf => accountEf.CartProducts)
            .ThenInclude(cartProductEf => cartProductEf.Product)
            .FirstOrDefaultAsync(x => x.Id == (int)accountId);
        return account.ContinueWith(x => x.Result?.CartProducts.ToList());
    }
}