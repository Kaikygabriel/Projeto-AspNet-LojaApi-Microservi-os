
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Exception;

namespace Shop.Cart.TEst.Domain.Entities;

public class CartITemTest
{
    private const string USERID_VALID = "KDfjslfsfdddd";
    private const string USERID_INVALID = "ted";
    private const string? USERID_NULL = null;

    private const int QUANTITY_VALID = 13;
    private const int QUANTITY_INVALID = -1;
    
    private readonly Product  ProductValid=
        new ("teste0",1.0m,30,"TESTESAFDAS","image.url");

    [Fact]
    public void CreateCartItem_UserIdValid_QuantityValid_Return_NotNull()
    {
        var cartItem = new CartItem(QUANTITY_VALID,ProductValid,USERID_VALID);
        Assert.NotNull(cartItem);
    }
    [Fact]
    public void CreateCartItem_UserInValid_QuantityInValid_Return_CartItemException()
    {
        Assert.Throws<CartItemException>(()
            => new CartItem(QUANTITY_INVALID,ProductValid,USERID_INVALID) 
        );
    }
    
    [Fact]
    public void CreateCartItem_UserNull_QuantityValid_Return_CartItemException()
    {
        Assert.Throws<CartItemException>(()
            => new CartItem(QUANTITY_VALID,ProductValid,USERID_NULL) 
        );
    }
}