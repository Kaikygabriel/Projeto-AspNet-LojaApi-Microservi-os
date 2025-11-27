using System.Linq.Expressions;
using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}