using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Auth.Models;
using Shop.Auth.Models.ObjectValues;

namespace Shop.Auth.Data.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.OwnsOne(x=>x.Email)
            .Property(x=>x.Address)
            .HasMaxLength(300)
            .HasColumnType("NVARCHAR")
            .IsRequired();
        
        builder.Property(x=>x.PasswordHash)
            .HasMaxLength(400)
            .HasColumnType("NVARCHAR");
        
        builder.Property(x=>x.Name)
            .HasMaxLength(250)
            .HasColumnType("NVARCHAR")
            .IsRequired();
    }
}