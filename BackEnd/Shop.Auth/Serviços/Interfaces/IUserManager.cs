using Shop.Auth.Models;

namespace Shop.Auth.Serviços.Interfaces;

public interface IUserManager
{
    Task<bool> CreateUser(User user);
    Task<User> FindUserByName(string name);
}