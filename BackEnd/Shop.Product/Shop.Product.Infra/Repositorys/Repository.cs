using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Abstraction;
using Shop.Domain.Interfaces;
using Shop.Product.Infra.Data.Context;

namespace Shop.Product.Infra.Repositorys;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public void Create(T entity)
    {
        if(entity is null)
            throw new ArgumentNullException(nameof(entity));
        Context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        if(entity is null)
            throw new ArgumentNullException(nameof(entity));
        Context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        if(entity is null)
            throw new ArgumentNullException(nameof(entity));
        Context.Set<T>().Remove(entity);
    }
}