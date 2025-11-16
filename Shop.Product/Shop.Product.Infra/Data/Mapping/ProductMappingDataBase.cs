using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Product.Infra.Data.Mapping;

public class ProductMappingDataBase : IEntityTypeConfiguration<Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
    {        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(x => x.Price)
            .HasColumnType("MONEY")
            .HasPrecision(10,2)
            .IsRequired();
        builder.Property(x => x.ImageUrl)
            .HasMaxLength(300)
            .IsRequired();
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.IdCategory)
            .IsRequired(false);
    }
}