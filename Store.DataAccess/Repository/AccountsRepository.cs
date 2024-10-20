using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repository;

public class AccountsRepository(StoreDbContext dbContext) : IRepository<AccountEf>
{
    public async Task<List<AccountEf>> GetAll() => 
        await dbContext.Accounts.AsNoTracking().ToListAsync();
    
    public async Task<AccountEf> Get(int id) => 
        await dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task Create(AccountEf accountEf)
    {
        await dbContext.Accounts.AddAsync(accountEf);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(AccountEf accountEf)
    {
        dbContext.Accounts.Update(accountEf);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        
        if (account != null)
        {
            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync();
        }
    }
}