using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repository;

public class OrdersRepository(StoreDbContext dbContext) : IRepository<OrderEf>
{
    public async Task<List<OrderEf>> GetAll() =>
        await dbContext.Orders.AsNoTracking().ToListAsync();
    
    public async Task<OrderEf> Get(int id) => 
        await dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task Create(OrderEf item)
    {
        await dbContext.Orders.AddAsync(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(OrderEf item)
    {
        dbContext.Orders.Update(item);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        
        if (order != null)
        {
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
        }
    }
}