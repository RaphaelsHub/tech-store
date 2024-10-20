using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;

namespace Store.DataAccess;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<ProductEf> Products { get; set; }
    public DbSet<OrderEf> Orders { get; set; }
    public DbSet<AccountEf> Accounts { get; set; }
}