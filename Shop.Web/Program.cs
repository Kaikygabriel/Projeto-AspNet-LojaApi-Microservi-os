using Shop.Web.Services;
using Shop.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("ProductApi",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ProductApi:UriBase"]!);
    x.DefaultRequestHeaders.Accept.ParseAdd("application/json");

});
builder.Services.AddScoped<IProductService, ProductService>();

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
