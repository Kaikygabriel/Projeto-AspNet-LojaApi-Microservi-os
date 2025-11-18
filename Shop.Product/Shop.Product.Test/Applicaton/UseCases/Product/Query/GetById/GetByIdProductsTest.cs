using Shop.Application.UseCases.Product.Query.GetById;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Product.Query.GetById;

public class GetByIdProductsTest
{
    private const int IdProductValid = 1;
    private const int IdProductInValid = 100;
    private readonly GetByIdProductHandler _handler;
    public GetByIdProductsTest()
    {
        _handler = new GetByIdProductHandler(new FakeUnitOfWork());
    }   
    [Fact]
    public async Task GetByIdProduct_IdValid_Return_Product()
    {
        var query = new GetByIdProductQuery(IdProductValid);
        var result = await _handler.Handle(query, CancellationToken.None);
        Assert.IsType<Shop.Application.DTOs.Product.ProductDto>(result);
    }
    
    [Fact]
    public async Task GetByIdProduct_IdInValid_Return_Null()
    {
        var query = new GetByIdProductQuery(IdProductInValid);
        var result = await _handler.Handle(query, CancellationToken.None);
        Assert.Null(result);
    }
}
