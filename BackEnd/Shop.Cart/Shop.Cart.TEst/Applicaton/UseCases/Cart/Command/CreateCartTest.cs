using Shop.Cart.Application.UseCases.Cart.Commands.Create;
using Shop.Cart.TEst.Mocks;

namespace Shop.Cart.TEst.Applicaton.UseCases.Cart.Command;

public class CreateCartTest
{
    private readonly CreateCartHandler _handler = new (new FakeUnitOfWork());
    private const string UserId = "user_12345";

    [Fact]
    public async Task CreateCart_CartNull_Return_False()
    {
        var command = new CreateCartCommand(null);
        var result = await _handler.HandleAsync(command);
        Assert.False(result);
    }
    [Fact]
    public async Task CreateCart_CartOk_Return_True()
    {
        var command = new CreateCartCommand(new Shop.Cart.Domain.Entities.Cart(UserId));
        var result = await _handler.HandleAsync(command);
        Assert.True(result);
    }
}