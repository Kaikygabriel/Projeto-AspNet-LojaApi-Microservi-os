using Microsoft.EntityFrameworkCore;
using Shop.Product.Api.Extensions.Category;
using Shop.Product.Api.Extensions.DependencyInjection;
using Shop.Product.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionSql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDependencyInjection();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionSql));

var app = builder.Build();


app.UseHttpsRedirection();

app.MapCategory();

app.Run();