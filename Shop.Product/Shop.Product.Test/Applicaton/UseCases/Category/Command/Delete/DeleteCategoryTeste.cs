using Shop.Application.UseCases.Category.Command.Create;
using Shop.Application.UseCases.Category.Command.Delete;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Category.Command.Delete;

public class DeleteCategoryTeste 
{
    private readonly DeleteCategoryHandler CategoryHandler = new(new FakeUnitOfWork());
    
    private readonly Shop.Domain.Entities.Category? CategoryNull = null;
    private readonly Shop.Domain.Entities.Category CategoryValid = new("Livros");
    [Fact]
    public async Task DeleteCategory_WithCategoryNull_Return_False()
    {
        //Arrange
        var command = new DeleteCategoryCommand(CategoryNull);
        //act
        var result = await CategoryHandler.Handle(command,default);
        //assert    
        Assert.False(result);
    }
    [Fact]
    public async Task DeleteCategory_WithCategoryValid_Return_True()
    {
        //Arrange
        var command = new DeleteCategoryCommand(CategoryValid);
        //act
        var result = await CategoryHandler.Handle(command,default);
        //assert    
        Assert.True(result);
    }
}