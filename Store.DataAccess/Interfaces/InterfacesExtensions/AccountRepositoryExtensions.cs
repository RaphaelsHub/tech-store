using Microsoft.EntityFrameworkCore;
using Store.DataAccess.ModelsEF;

namespace Store.DataAccess.Interfaces.InterfacesExtensions;

public static class AccountRepositoryExtensions
{
    public static async Task<AccountEf?> FindByEmailAsync(
        this IRepository<AccountEf> repository, 
        StoreDbContext dbContext, 
        string email) => await dbContext.
                        Accounts.
                        AsNoTracking().
                        FirstOrDefaultAsync(m => m.Email == email);
}
