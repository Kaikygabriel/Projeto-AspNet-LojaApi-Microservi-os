using Shop.Cart.Domain.Exception;

namespace Shop.Cart.Domain.ObjectValues;

public class CartHeader 
{
    public CartHeader(){}
    public CartHeader(string userId)
    {
        ValidateUserId(userId);
        UserId = userId;
    }
    
    public string UserId { get; set; }

    public void ValidateUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId)|| userId.Length < 5)
            throw new CartException("The user id is invalid ");
    }
}