using Shop.Application.UseCases.Category.Query.GetByName;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Category.Query.GetByName;

public class GetByNameTest
{
    private readonly GetByNameCategoryHandler CategoryHandler= new(new FakeUniOfWork());

    private const string? NameNull = null;
    private const string NameNoExisting = "teste";
    private const string NameValid = "Livros";

    [Fact]
    public async Task GetByNameHandler_WithNameNull_Return_Null()
    {
        var query = new GetByNameCategoryQuery(NameNull);
        var result = await CategoryHandler.Handle(query,CancellationToken.None);
        Assert.Null(result);
    }
    [Fact]
    public async Task GetByNameHandler_WithNameNoExinst_Return_Null()
    {
        var query = new GetByNameCategoryQuery(NameNoExisting);
        var result = await CategoryHandler.Handle(query,CancellationToken.None);
        Assert.Null(result);
    }
    [Fact]
    public async Task GetByNameHandler_WithNameValid_Return_Category()
    {
        var query = new GetByNameCategoryQuery(NameValid);
        var result = await CategoryHandler.Handle(query,CancellationToken.None);
        Assert.IsType<Shop.Domain.Entities.Category>(result);
    }
    
}