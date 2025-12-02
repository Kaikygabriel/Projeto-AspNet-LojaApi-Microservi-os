using Shop.Discont.Application.UseCases.Cupom.Command.Create;
using Shop.Discont.Test.Mock;

namespace Shop.Discont.Test.Application.UseCases.Cupom.Command;

public class CreateTest
{
    private readonly CreateHandler _handler = new (new FakeCupomRepository());
    private readonly Discont.Domain.BackOffice.Entitites.Cupom CupomNull = null;
    private readonly Discont.Domain.BackOffice.Entitites.Cupom CupomValid = new ("teste",20);
    private readonly Discont.Domain.BackOffice.Entitites.Cupom CupomInValid = new ("Desconto10", 10);

    [Fact]
    public async Task CreateCupom_Existing_Return_False()
    {
        var command = new CreateCommand(CupomInValid);
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    } 
    [Fact]
    public async Task CreateCupom_Null_Return_False()
    {
        var command = new CreateCommand(CupomNull);
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    } 
    [Fact]
    public async Task CreateCupom_Valid_Return_True()
    {
        var command = new CreateCommand(CupomValid);
        var result = await _handler.Handle(command,default);
        Assert.True(result);
    } 
}