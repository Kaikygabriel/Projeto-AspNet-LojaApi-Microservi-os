using Shop.Cart.Application.UseCases.Cart.Commands.ApplyItemInCart;
using Shop.Cart.Domain.Entities;
using Shop.Cart.TEst.Mocks;

namespace Shop.Cart.TEst.Applicaton.UseCases.Cart.Command;

public class AddItemInCartTest
{
    private readonly AddItemInCartHandler _cartHandler = new AddItemInCartHandler(new FakeUnitOfWork()); 
    private readonly CartItem? CARTITEM_NULL = null;
    private readonly CartItem CARTITEM_VALID = new CartItem(1,new Product(),"user_12345");

    private const string USERID_VALID = "user_12345";
    private const string USERID_INVALID = "dfasjdfklabcd";
    [Fact]
    public async Task AddItemInCart_WithCartItemNull_Return_False()
    {
        //arrange
        var command = new AddItemInCartCommand(CARTITEM_NULL,USERID_VALID);
        //act
        var result = await _cartHandler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
    [Fact]
    public async Task AddItemInCart_WithCartItemOk_Return_True()
    {
        //arrange
        var command = new AddItemInCartCommand(CARTITEM_VALID,USERID_VALID);
        //act
        var result = await _cartHandler.HandleAsync(command);
        //assert
        Assert.True(result);
    }
    [Fact]
    public async Task AddItemInCart_UserIdNoExisting_Return_False()
    {
        //arrange
        var command = new AddItemInCartCommand(CARTITEM_VALID,USERID_INVALID);
        //act
        var result = await _cartHandler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
}