using Shop.Application.DTOs.Product;
using Shop.Application.UseCases.Product.Query.GetByName;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Product.Query.GetByName;

public class GetByNameProductTest
{
    private readonly GetByNameProductHandler Handler = new(new FakeUnitOfWork());

    private const string? NameNull = null;
    private const string NameNoExisting = "teste";
    private const string NameValid = "Smartphone Samsung Galaxy S23";
    
    [Fact]
    public async Task GetByNameProduct_NameNull_Return_Null()
    {
        // arrange
        var query = new GetByNameProductQuery(NameNull);
        //act
        var result = await Handler.Handle(query, default);
        //assert
        Assert.Null(result);
    }
    [Fact]
    public async Task GetByNameProduct_NameNoExisting_Return_Null()
    {
        // arrange
        var query = new GetByNameProductQuery(NameNoExisting);
        //act
        var result = await Handler.Handle(query, default);
        //assert
        Assert.Null(result);
    }
    [Fact]
    public async Task GetByNameProduct_NameValid_Return_ProductDto()
    {
        // arrange
        var query = new GetByNameProductQuery(NameValid);
        //act
        var result = await Handler.Handle(query, default);
        //assert
        Assert.IsType<ProductDto>(result);
    }
}