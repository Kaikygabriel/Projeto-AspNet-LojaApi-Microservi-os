using Shop.Application.UseCases.Category.Query.GetAll;
using Shop.Product.Test.Mocks;

namespace Shop.Product.Test.Applicaton.UseCases.Category.Query.GetByName.GetAll;

public class GetAllCategoryTest
{
    private readonly GetAllCategoryHandler _handler;

    public GetAllCategoryTest()
    {
        _handler = new GetAllCategoryHandler(new FakeUnitOfWork());
    }

    [Fact]
    public async Task GetAllCategorys_Return_IEnumerable_Type_Category()
    {
        // Arrange
        var query = new GetAllCategoryQuery();
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);
        // Assert
        Assert.IsAssignableFrom<IEnumerable<Shop.Domain.Entities.Category>>(result);
    }
}
