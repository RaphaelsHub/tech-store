using Store.DataAccess;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Interfaces;
using Store.DataAccess.ModelsEF;
using Store.DataAccess.Repository;
using Store.ServiceMapper;

namespace Store;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        // builder.Services.AddDbContext<StoreDbContext>(options =>
        // {       
        //     options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDbContext"));
        // });

        builder.Services.AddDbContext<StoreDbContext>(options =>
            options.UseNpgsql(
                "Host=localhost;" +
                "Port=5432;" +
                "Database=StoreHub;" +
                "Username=postgres;" +
                "Password=2003")
        );

        builder.Services.AddScoped<IRepository<AccountEf>, AccountsRepository>();
        builder.Services.AddScoped<IRepository<ProductEf>, ProductsRepository>();
        builder.Services.AddScoped<IRepository<OrderEf>, OrdersRepository>();
        builder.Services.AddScoped<CartsRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapGet("/", context =>
        {
            context.Response.Redirect("/Home/Index");
            return Task.CompletedTask;
        });

        app.Run();
    }
}