using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.IdentityServer.Configuration;
using Shop.IdentityServer.Data;
using Shop.IdentityServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var builderIdentity = builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.EmitStaticAudienceClaim = true;
    })
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityRosources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddAspNetIdentity<ApplicationUser>();
builderIdentity.AddDeveloperSigningCredential();
builderIdentity.AddTestUsers(TestUsers.Users);


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
