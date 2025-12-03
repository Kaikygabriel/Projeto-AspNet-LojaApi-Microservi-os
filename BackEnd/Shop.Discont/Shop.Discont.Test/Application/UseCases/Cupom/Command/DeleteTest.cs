using Shop.Discont.Application.UseCases.Cupom.Command.Delete;
using Shop.Discont.Test.Mock;

namespace Shop.Discont.Test.Application.UseCases.Cupom.Command;

public class DeleteTest
{
    private readonly DeleteHandler _handler = new DeleteHandler(new FakeCupomRepository());
    
    private const int ID_VALID = 1;
    private const int ID_INVALID = 2;

    [Fact]
    public async Task DeleteCupom_IdInvalid_Return_False()
    {
        var command = new DeleteCommand(ID_INVALID);
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    }
    [Fact]
    public async Task DeleteCupom_IdValid_Return_True()
    {
        var command = new DeleteCommand(ID_VALID);
        var result = await _handler.Handle(command,default);
        Assert.True(result);
    }
}