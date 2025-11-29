using System.Collections.ObjectModel;
using Shop.Cart.Domain.Exception;
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Domain.Entities;

public class Cart : Entity
{
    public Cart(){}
    public Cart(string userId)
    {
        ValidateUserId(userId);
        UserId = userId;
    }
    
    public string UserId { get; set; }
    public List<CartItem> Items { get; set; } = new();
    

    public void AddItemsInCart(CartItem item)
        => Items.Add(item);
    public IEnumerable<CartItem> GetItemsInCart(CartItem item)
        => Items;
    public void RemoveItemInCart(CartItem item)
        => Items.Remove(item);

    public void CleanItems()
        => Items.Clear();
    
    public void ValidateUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new CartException("The user id is invalid ");
        if ( userId.Length < 3)
            throw new CartException("teste ");
    }
        
}