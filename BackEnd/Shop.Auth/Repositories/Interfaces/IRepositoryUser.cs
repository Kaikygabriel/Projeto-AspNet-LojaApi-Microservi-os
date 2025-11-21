using System.Linq.Expressions;
using Shop.Auth.Models;

namespace Shop.Auth.Repositories.Interfaces;

public interface IRepositoryUser
{
    Task<User> GetByPredicate(Expression<Func<User, bool>> predicate);
    void Create(User entity);
    void Update(User entity);
    void Delete(User entity);
}