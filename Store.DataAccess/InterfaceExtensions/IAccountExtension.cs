using Store.DataAccess.Entities;
using Store.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Store.DataAccess.InterfaceExtensions;

public static class IAccountExtension
{
    private static StoreDbContext dbContext;
    
    public static AccountEf? FindUser(this IRepository<AccountEf> repository, string email)
    {
        return dbContext.Accounts.FirstOrDefault(x => x.Email == email);
    }
}