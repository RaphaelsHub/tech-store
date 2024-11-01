using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;

namespace Store.DataAccess.Repository;

public class OrdersRepository(StoreDbContext db) : IRepository<OrderEf>
{
    public async Task<IEnumerable<OrderEf>> GetAllAsync() =>
        await db.Orders.AsNoTracking().ToListAsync();
    public async Task<OrderEf?> GetAsync(uint id) => 
        await db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
    public async Task<bool> CreateAsync(OrderEf item)
    {
        await db.Orders.AddAsync(item);
        await db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAsync(OrderEf item)
    {
        db.Orders.Update(item);
        await db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(uint id)
    {
        var order = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);
        
        if (order != null)
        {
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
        }
        
        return !db.Orders.Any(x => x.Id == (int)id);
    }
}