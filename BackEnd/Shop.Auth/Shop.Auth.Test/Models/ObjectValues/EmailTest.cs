using Shop.Auth.Models.ObjectValues;

namespace Shop.Auth.Test.Models.ObjectValues;

public class EmailTest
{
    private const string AddressValid = "teste@gmail.com";
    private const string AddressInValid = "teste";
    private const string? AddressNull = null;

    [Fact]
    public void CreateEmail_With_AddressInValid_Return_Exception()
    {
        Assert.Throws<Exception>(()
            => new Email(AddressInValid));
    }

    [Fact]
    public void CreateEmail_With_AddressNull_Return_Exception()
    {
        
        Assert.Throws<Exception>(()
            => new Email(AddressNull));
    }

    [Fact]
    public void CreateEmail_With_AddressValid_Return_Email()
    {
        
        var email = new Email(AddressValid);
        Assert.IsType<Email>(email);
    }
}