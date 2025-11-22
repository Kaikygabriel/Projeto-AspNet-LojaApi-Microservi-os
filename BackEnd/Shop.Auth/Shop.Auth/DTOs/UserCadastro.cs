using Shop.Auth.Models;
using Shop.Auth.Models.ObjectValues;

namespace Shop.Authh.DTOs;

public class UserCadastro
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public static implicit operator UserCadastro(User user)
    {
        return new UserCadastro()
        {
            Email = user.Email.Address,
            PasswordHash = user.PasswordHash,
            Name = user.Name
        };
    }
    public static implicit operator User(UserCadastro userCadastro)
    {
        return new User(userCadastro.Name, userCadastro.Email, userCadastro.PasswordHash);
    }
}