using Shop.Auth.Models;
using Shop.Auth.Models.ObjectValues;

namespace Shop.Auth.Test.Models.Entities;

public class UserTest
{
    private const string NameValid = "teste";
    private const string NameInvalid = "te";
    private const string? NameNull = null;

    private const string PasswordValid = "12344566";
    private const string PasswordInvalid = "12";
    private const string? PasswordNull = null;
    
    private const string Email = "Teste@gmail.com";
    [Fact]
    public void CreateUser_With_NameInValid_PasswordInvalid_Return_Exception()
    {
        Assert.Throws<Exception>(()
            => new User(NameInvalid,Email,PasswordInvalid));
    }
    
    [Fact]
    public void CreateUser_With_NameValid_PasswordValid_Return_UserType()
    {
        var user = new User(NameValid,Email,PasswordValid);
        Assert.IsType<User>(user);
    }
    
    [Fact]
    public void CreateUser_With_NameNull_PasswordNull_Return_Exception()
    {
        Assert.Throws<Exception>(()
            => new User(NameNull,Email,PasswordNull));
    }
}