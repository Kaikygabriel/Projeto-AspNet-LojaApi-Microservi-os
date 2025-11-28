using Shop.Web.Cart.Services;
using Shop.Web.Category.Interfaces;
using Shop.Web.Category.Services;
using Shop.Web.Products.Interfaces;
using Shop.Web.Products.Services;
using Shop.Web.User.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ProductApi",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ProductApi:UriBase"]!);
    x.DefaultRequestHeaders.Accept.ParseAdd("application/json");
});
builder.Services.AddHttpClient("AuthApi",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["AuthApi:UriBase"]!);
    x.DefaultRequestHeaders.Accept.ParseAdd("application/json");
});
builder.Services.AddHttpClient("CartApi",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["CartApi:UriBase"]!);
    x.DefaultRequestHeaders.Accept.ParseAdd("application/json");
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ServiceAuth>();
builder.Services.AddScoped<CartService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
