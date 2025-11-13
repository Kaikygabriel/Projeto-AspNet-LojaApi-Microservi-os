using Shop.Application.UseCases.Category.Command.Create;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Category.Command.Create;

public class CreateCategoryTest  
{
    private readonly CreateCategoryHandler CategoryHandler = new(new FakeUniOfWork());
    private const string NameValid = "teste";
    
    [Fact]
    public async Task CreateCategoryHandler_WithCategoryNull_Return_False()
    {
        //arrange
        CreateCategoryCommand categoryCommand=
            new CreateCategoryCommand(null);
        //Act
        var result = await CategoryHandler.Handle(categoryCommand,default);
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public async Task CreateCategoryHandler_WithCategoryValid_Return_False()
    {
        //arrange
        CreateCategoryCommand categoryCommand=
            new CreateCategoryCommand(new Shop.Domain.Entities.Category(NameValid));
        //Act
        var result = await CategoryHandler.Handle(categoryCommand,default);
        //Assert
        Assert.True(result);
    }
}