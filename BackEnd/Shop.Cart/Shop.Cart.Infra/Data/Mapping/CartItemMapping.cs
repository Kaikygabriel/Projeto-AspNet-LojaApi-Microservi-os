using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Infra.Data.Mapping;

public class CartItemMapping : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        
    }
}