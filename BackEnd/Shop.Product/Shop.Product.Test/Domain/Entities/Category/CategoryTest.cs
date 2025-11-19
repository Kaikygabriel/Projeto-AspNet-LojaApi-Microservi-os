using Shop.Domain.Exceptions;

namespace Shop.Product.Test.Domain.Entities.Category;

public class CategoryTest
{
    private const string NameValid = "teste";
    private const string NameInvalid = "t";
    private const string NameNull = null;

    [Fact]
    public void CreateCategory_NameInvalid_Return_CategoryException()
    {
        Assert.Throws<CategoryException>(() =>
            new Shop.Domain.Entities.Category(NameInvalid));
    }
    [Fact]
    public void CreateCategory_NameNull_Return_CategoryException()
    {
        Assert.Throws<CategoryException>(() =>
            new Shop.Domain.Entities.Category(NameNull));
    }
    [Fact]
    public void CreateCategory_NameValid_Return_NotNull()
    {
        var category = new Shop.Domain.Entities.Category(NameValid);
        Assert.NotNull(category);
    }
}