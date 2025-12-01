using System.Linq.Expressions;
using Shop.Discont.Domain.BackOffice.Entitites;

namespace Shop.Discont.Domain.BackOffice.Interfaces;

public interface IRepositoryCupom
{
    Task<IEnumerable<Cupom>> GetAllAsync();
    Task<Cupom?> GetByPredicate(Expression<Func<Cupom,bool>>predicate);

    Task Create(Cupom entity);
    Task Update(Cupom entity);
    Task Delete(Cupom entity);
}