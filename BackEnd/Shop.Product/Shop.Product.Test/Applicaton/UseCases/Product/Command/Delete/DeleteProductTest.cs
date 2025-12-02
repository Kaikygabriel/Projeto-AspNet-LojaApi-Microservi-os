using Microsoft.Extensions.Caching.Memory;
using Shop.Application.UseCases.Product.Command.Create;
using Shop.Application.UseCases.Product.Command.Delete;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Product.Command.Delete;

public class DeleteProductTest
{

    private readonly DeleteProductHandler Handler = new(new FakeUnitOfWork(),new MemoryCache(new MemoryCacheOptions()));
    private readonly Shop.Domain.Entities.Product? ProductNull = null;
    private readonly Shop.Domain.Entities.Product ProductValid = new
    (name: "Teclado Mecânico Redragon Kumara",
        price: 250.00m,
        stock: 35,
        description: "Teclado mecânico ABNT2 com switches Outemu Blue e iluminação RGB.",
        imageUrl: "https://example.com/images/redragon-kumara.jpg", 1);

    [Fact]
    public async Task DeleteProduct_WithProductNull_Return_False()
    {
        var command = new DeleteProductCommand(ProductNull);
        var result = await Handler.Handle(command, default);
        Assert.False(result);
    }
    [Fact]
    public async Task DeleteProduct_WithProductValid_Return_True()
    {
        var command = new DeleteProductCommand(ProductValid);
        var result = await Handler.Handle(command, default);
        Assert.True(result);
    }
}