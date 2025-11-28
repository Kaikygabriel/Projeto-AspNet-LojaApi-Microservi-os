using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Infra.Data.Mapping;

public class CartMapping : IEntityTypeConfiguration<Domain.Entities.Cart>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Cart> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.UserId)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasMany(x => x.Items)
            .WithOne(x => x.Cart)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}