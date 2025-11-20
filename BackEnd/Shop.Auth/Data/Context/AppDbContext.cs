using Microsoft.EntityFrameworkCore;
using Shop.Auth.Data.Mapping;
using Shop.Auth.Models;

namespace Shop.Auth.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext>options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
    }
}