using Shop.Domain.Entities;
using Shop.Domain.Exceptions;

namespace Shop.Product.Test.Domain.Entities.Product;

public class ProductTest
{
    private const string NameValid = "Teste";
    private const string NameInvalid = "te";
    private const string? NameNull = null;
    
    private const string DescriptionValid = "Teste";
    private const string DescriptionInvalid = "te";
    private const string? DescriptionNull = null;

    private const string ImageUrlValid = "Teste";
    private const string ImageUrlInvalid = "t";
    private const string? ImageUrlNull = null;

    private const decimal PriceValid = 100;
    private const decimal PriceInvalid = 0;

    private const int StockValid = 1;
    private const int CategoryValid = 1;

    [Fact]
    public void CreateProduct_NameInvalid_DescriptionInvalid_ImageUrlInvalid_PriceInvalid_Return_ProductException()
    {
        Assert.Throws<ProductException>(() => 
            new Shop.Domain.Entities.Product(NameInvalid,PriceInvalid,StockValid,DescriptionInvalid,ImageUrlInvalid,CategoryValid));
    }
    [Fact]
    public void CreateProduct_NameNull_DescriptionNull_ImageUrlNull_PriceValid_Return_ProductException()
    {
        Assert.Throws<ProductException>(() => 
            new Shop.Domain.Entities.Product(NameNull,PriceValid,StockValid,DescriptionNull,ImageUrlNull,CategoryValid));
    }
    [Fact]
    public void CreateProduct_NameValid_DescriptionValid_ImageUrlValid_PriceValid_Return_NotNull()
    {
          var product = new Shop.Domain.Entities.Product(NameValid,PriceValid,StockValid,DescriptionValid,ImageUrlValid,CategoryValid);

          Assert.NotNull(product);
    }
}