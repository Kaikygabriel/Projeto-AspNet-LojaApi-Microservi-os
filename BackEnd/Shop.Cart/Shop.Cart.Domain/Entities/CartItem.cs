using Shop.Cart.Domain.Exception;
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Domain.Entities;

public class CartItem : Entity
{
    public CartItem(){}
    public CartItem(int quantity, Product product, string userId)
    {
        ValidateQuantity(quantity);
        ValidateUserId(userId);
        Quantity = quantity;
        Product = product;
        UserId = userId;
    }

    public int Quantity { get; set; }
    public int ProductId { get; set; }

    public Product Product { get; set; }
    public string UserId { get; set; }


    public Cart Cart { get; set; }
    public int CartId { get; set; }
    public void ValidateQuantity(int quantity)
    {
        if(quantity < 0)
            throw new CartItemException("The quantity is less than one.");
    }

    public void ValidateUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId)|| userId.Length < 5)
            throw new CartItemException("The user id is invalid ");
    }
}