using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Application.Dto;

public class CartDto
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }

    public Product Product { get; set; }
    public string UserId { get; set; }

    public static implicit operator CartItem(CartDto cart)
    {
        return new CartItem(cart.Quantity, cart.Product, cart.UserId);
    }
}