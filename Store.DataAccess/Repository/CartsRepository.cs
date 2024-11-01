using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;

namespace Store.DataAccess.Repository;

public class CartsRepository(StoreDbContext db)
{
    public async Task<bool> AddProductAsync(uint accountId, uint quantity, uint productId)
    {
        var trackedProduct = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);

        if (trackedProduct == null) return false;

        //Получить аккаунт и все продукты в его корзине(Include) без него ентити подгружаться не будут 
        var account = await db.Accounts.Include(accountEf => accountEf.CartProducts)
            .FirstOrDefaultAsync(x => x.Id == (int)accountId);

        if (account == null || trackedProduct.Quantity < quantity) return false;
        trackedProduct.Quantity -= quantity;

        db.Products.Update(trackedProduct);

        if(account.CartProducts.Any(x=>x.ProductId==productId))
        {
            var cartProduct = account.CartProducts.FirstOrDefault(x => x.ProductId == productId);
            if (cartProduct != null) cartProduct.Quantity += quantity;
        }
        else
        {
            var cartProduct = new CartProductEf{ AccountId = (int)accountId, ProductId = (int)productId, Quantity = quantity };
            account.CartProducts.Add(cartProduct);

        }
        
        await db.SaveChangesAsync();
        return true;
    }


    public async Task<List<CartProductEf>?> GetCartProductsAsync(uint accountId)
    {
        var account = await db.Accounts.Include(accountEf => accountEf.CartProducts)
            .ThenInclude(cartProductEf => cartProductEf.Product)
            .FirstOrDefaultAsync(x => x.Id == (int)accountId);

        if (account == null) return null;
        
        return account.CartProducts.ToList();
    }
        
        
         // await db.Accounts.
         //    Include(obj=>obj.CartProducts).
         //    FirstOrDefaultAsync(obj => obj.Id == (int)accountId).
         //    ContinueWith(obj => obj.Result?.CartProducts.ToList() ?? new List<CartProductEf>());
}