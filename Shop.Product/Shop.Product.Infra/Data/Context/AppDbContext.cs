using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Product.Infra.Data.Mapping;

namespace Shop.Product.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<Domain.Entities.Product>Products { get; set; }
    public DbSet<Category>Categorys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new CategoryMapping());
    }
}