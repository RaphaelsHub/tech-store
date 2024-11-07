using Microsoft.EntityFrameworkCore;
using Store.DataAccess.ModelsEF;

namespace Store.DataAccess;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        //CreateData();
    }
    
    public DbSet<ProductEf> Products { get; set; }
    public DbSet<OrderEf> Orders { get; set; }
    public DbSet<AccountEf> Accounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // AccountEf
        modelBuilder.Entity<AccountEf>()
            .HasKey(m => m.Id);
        
        modelBuilder.Entity<AccountEf>()
            .HasMany(m=>m.Orders)
            .WithOne(m=>m.Account);

        modelBuilder.Entity<AccountEf>()
            .HasMany(m => m.CartProducts)
            .WithMany();
        
        // ProductEf
        modelBuilder.Entity<ProductEf>()
            .HasKey(m => m.Id);
        
        modelBuilder.Entity<ProductEf>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        
        
        // OrderEf
        modelBuilder.Entity<OrderEf>()
            .HasKey(m => m.Id);
        
        modelBuilder.Entity<OrderEf>()
            .HasOne(x=>x.Account)
            .WithMany()
            .HasForeignKey(x=>x.AccountId);
        
        modelBuilder.Entity<OrderEf>()
            .HasMany(m => m.Products)
            .WithMany();
        
        
        // CartProductEf
        modelBuilder.Entity<CartProductEf>()
            .HasKey(m=>new {m.AccountId, m.ProductId});
       
        modelBuilder.Entity<CartProductEf>()
            .HasOne(m => m.Account)
            .WithMany()
            .HasForeignKey(m => m.AccountId);
        
        modelBuilder.Entity<CartProductEf>()
            .HasOne(m => m.Product)
            .WithMany()
            .HasForeignKey(m => m.ProductId);

        // OrderProductEf
        modelBuilder.Entity<OrderProductEf>()
            .HasKey(m=>new {m.AccountId, m.ProductId});
        
        modelBuilder.Entity<OrderProductEf>()
            .HasOne(m => m.Account)
            .WithMany()
            .HasForeignKey(m => m.AccountId);
        
        modelBuilder.Entity<OrderProductEf>()
            .HasOne(m => m.Product)
            .WithMany()
            .HasForeignKey(m => m.ProductId);
    }
}

// private void CreateData()
// {
//     var productEfs = new List<ProductEf>();
//     var accountEfs = new List<AccountEf>();
//     var orderEfs = new List<OrderEf>();
//         
//     for (int i = 0; i < 10; i++)
//     {
//         var product = new ProductEf
//         {
//             Name = $"Product {i}",
//             ShortDescription = $"Short description {i}",
//             FullDescription = $"Full description {i}",
//             Price = 10 + i,
//             Quantity = 10,
//             Category = "Category",
//             Photo = File.ReadAllBytes("wwwroot/images/productTemplate.png") 
//         };
//         productEfs.Add(product);
//     }
//
//     Products.AddRange(productEfs);
//     SaveChanges();
//
//     for (int i = 0; i < 10; i++)
//     {
//         var account = new AccountEf
//         {
//             Name = $"Account {i}",
//             Email = $"user1{i}@gmail.com",
//             Number = $"1234567890{i}",
//             PasswordHash = "$Rubi123!{i}"
//         };
//             
//         accountEfs.Add(account);
//     }
//         
//     Accounts.AddRange(accountEfs);
//     SaveChanges();
//
//     for (int i = 0; i < 10; i++)
//     {
//         var order = new OrderEf
//         {
//             Name = $"Order {i}",
//             Email = $"user1{i}@gmail.com",
//             Phone = $"1234567890{i}",
//             Country = "Country",
//             City = "City",
//             Address = "Address",
//             Comment = "Comment",
//             Products = new List<ProductEf> { productEfs.First() }
//         };
//             
//         orderEfs.Add(order);
//     }
//         
//     Orders.AddRange(orderEfs);
//     SaveChanges();
//         
//     Console.WriteLine("All data created");
// }