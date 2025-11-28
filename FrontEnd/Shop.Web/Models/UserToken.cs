namespace Shop.Web.Models;

public class UserToken
{
    public User.Models.User user { get; set; }
    public string Token { get; set; }
}