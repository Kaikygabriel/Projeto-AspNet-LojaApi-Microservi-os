using Shop.Cart.Application.UseCases.Cart.Commands.DeleteItemCart;
using Shop.Cart.TEst.Mocks;

namespace Shop.Cart.TEst.Applicaton.UseCases.Cart.Command;

public class DeleteItemInCartTest
{
    private readonly DeleteItemInCartHandler _handler= new (new FakeUnitOfWork());

    private const int ID_CARTITEM_VALID = 2;
    private const int ID_CARTITEM_INVALID = 13232;

    private const string ID_USER_VALID = "user_12345";
    private const string ID_USER_INVALID = "abcde";

    [Fact]
    public async Task DeleteItem_IdCartItemInvalid_Return_False()
    {
        //arrange
        var command = new DeleteItemInCartCommand(ID_CARTITEM_INVALID, ID_USER_VALID);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
    
    [Fact]
    public async Task DeleteItem_IdCartItemValid_Return_True()
    {
        
        //arrange
        var command = new DeleteItemInCartCommand(ID_CARTITEM_VALID, ID_USER_VALID);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.True(result);
    }
    
    [Fact]
    public async Task DeleteItem_IdUserInvalid_Return_False()
    {
        //arrange
        var command = new DeleteItemInCartCommand(ID_CARTITEM_VALID, ID_USER_INVALID);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
    
    [Fact]
    public async Task DeleteItem_IdUserValid_Return_True()
    {
        //arrange
        var command = new DeleteItemInCartCommand(2, ID_USER_VALID);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.True(result);
    }
}