using Shop.Web.Category.Interfaces;
using Shop.Web.Category.Services;
using Shop.Web.Products.Interfaces;
using Shop.Web.Products.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ProductApi",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ProductApi:UriBase"]!);
    x.DefaultRequestHeaders.Accept.ParseAdd("application/json");

});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

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
