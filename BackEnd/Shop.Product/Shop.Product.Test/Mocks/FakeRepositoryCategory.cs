using System.Linq.Expressions;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces.Categorys;

namespace Shop.Product.Test.Mocks;

public class FakeRepositoryCategory : IRepositoryCategory
{
    private List<Category> _categories = new()
    {
        new Category("Eletrônicos"),
        new Category("Roupas"),
        new Category("Livros"),
        new Category("Alimentos"),
        new Category("Bebidas"),
        new Category("Brinquedos"),
        new Category("Esportes"),
        new Category("Móveis"),
        new Category("Informática"),
        new Category("Beleza")
    };
    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Category>>(_categories);
    }

    public Task<Category> GetByPredicate(Expression<Func<Category, bool>> predicate)
    {
        return Task.FromResult<Category>(_categories.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Category entity)
    {
        if (entity is null)
            throw new Exception();
        _categories.Add(entity);
    }

    public void Update(Category entity)
    {
        if (entity is null)
            throw new Exception();
        _categories.Add(entity);
    }

    public void Delete(Category entity)
    {
        if (entity is null)
            throw new Exception();
        _categories.Remove(entity);
    }
}