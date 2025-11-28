using Microsoft.EntityFrameworkCore;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.ObjectValues;
using Shop.Cart.Infra.Data.Mapping;

namespace Shop.Cart.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<Domain.Entities.Cart>Cart { get; set; }
    public DbSet<Product>Products{ get; set; }
    public DbSet<CartItem>CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartMapping());
        modelBuilder.ApplyConfiguration(new CartItemMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());  
    }
}