namespace Shop.Web.Cart.Models;

public class Cart
{
    public Cart()
    {
        
    }
    public Cart(string userId)
    {
        UserId = userId;
    }

    public int Id { get; set; }
    public string UserId { get; set; }
    public List<CartItem> Items { get; set; } = new();
}