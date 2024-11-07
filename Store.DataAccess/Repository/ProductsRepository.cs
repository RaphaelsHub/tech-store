using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Microsoft.EntityFrameworkCore;


namespace Store.DataAccess.Repository;

public class ProductsRepository(StoreDbContext db) : IRepository<ProductEf>
{
    public async Task<IEnumerable<ProductEf>> GetAllAsync() =>
        await db.Products.AsNoTracking().ToListAsync();

    public async Task<ProductEf?> GetAsync(uint id) => 
        await db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
    
    public async Task<bool> CreateAsync(ProductEf item)
    {
        await db.Products.AddAsync(item);
        await db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAsync(ProductEf item)
    {
        db.Products.Update(item);
        await db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(uint id)
    {
        var product = await db.Products.FirstOrDefaultAsync(x => x.Id == (int)id);
        
        if (product != null)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
        return !db.Products.Any(x=> x.Id == (int)id);
    }
}