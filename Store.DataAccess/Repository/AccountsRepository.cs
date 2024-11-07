using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;


namespace Store.DataAccess.Repository;

public class AccountsRepository(StoreDbContext db) : IRepository<AccountEf>
{
    public async Task<IEnumerable<AccountEf>> GetAllAsync() =>
        await db.Accounts.AsNoTracking().ToListAsync();
    public async Task<AccountEf?> GetAsync(uint id) => 
        await db.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
    public async Task<bool> CreateAsync(AccountEf accountEf)
    {
        await db.Accounts.AddAsync(accountEf);
        await db.SaveChangesAsync();

        return db.Accounts.Any(x => x.Email == accountEf.Email);
    }
    public async Task<bool> UpdateAsync(AccountEf accountEf)
    {
        db.Accounts.Update(accountEf);
        await db.SaveChangesAsync();
        
        return true;
    }
    public async Task<bool> DeleteAsync(uint id)
    {
        var account = await db.Accounts.FirstOrDefaultAsync(x => x.Id == (int)id);
        
        if (account != null)
        {
            db.Accounts.Remove(account);
            await db.SaveChangesAsync();
        }

        return !db.Accounts.Any(x => x.Id == (int)id);
    }
    public async Task<AccountEf?> FindByEmailAsync(string email) => 
        await db.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
}