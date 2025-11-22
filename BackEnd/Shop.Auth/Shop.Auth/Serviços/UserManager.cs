using Shop.Auth.Models;
using Shop.Auth.Repositories.Interfaces;
using Shop.Auth.Serviços.Interfaces;

namespace Shop.Auth.Serviços;

public class UserManager : IUserManager
{
    private IUnitOfWork _unitOfWork;

    public UserManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateUser(User user)
    {
        try
        {
            if (await FindUserByEmail(user.Email.Address) is not null || !user.IsValid())
                return false;
            var password = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.PasswordHash = password;
            _unitOfWork.RepositoryUser.Create(user);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<User?> FindUserByName(string name)
    {
        return await _unitOfWork.RepositoryUser.GetByPredicate(x => x.Name == name);
    }
    public async Task<User?> FindUserByEmail(string email)
    {
        return await _unitOfWork.RepositoryUser.GetByPredicate(x => x.Email.Address == email);
    }

    public bool CheckPassword(User user, string Password)
        => BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash);
}