using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddDbContext<FruitableStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDB"));
});

//DI
builder.Services.AddSingleton<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
builder.Services.AddSingleton<IRepository<Product>, ProductRepository>();
builder.Services.AddSingleton<UserDetailFactory, ConcreteUserDetailFactory>();
builder.Services.AddScoped<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddSingleton<ProductFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*app.MapAreaControllerRoute(
    name: "default",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action}/{id?}",
    defaults: new { controller = "User", action = "Index" }
    );*/

app.MapAreaControllerRoute(
    name: "default",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action}/{id?}",
    defaults: new { controller = "Account", action = "Login" }
    );

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();

/*Scaffold-DBContext "Server=ADMIN-GK4O6HCO7\SQLEXPRESS;uid=sa;password=1;database=fruitable_store;Encrypt=true;TrustServerCertificate=true" Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models*/
