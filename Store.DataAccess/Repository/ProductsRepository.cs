using System.Data.Entity;
using Store.DataAccess.Entities;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repository;

public class ProductsRepository(StoreDbContext dbContext) : IRepository<ProductEf>
{
    public async Task<List<ProductEf>> GetAll() => 
        await dbContext.Products.AsNoTracking().ToListAsync();
    
    public async Task<ProductEf> Get(int id) => 
        await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task Create(ProductEf item)
    {
        await dbContext.Products.AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(ProductEf item)
    {
        dbContext.Products.Update(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        if (product != null)
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }
}