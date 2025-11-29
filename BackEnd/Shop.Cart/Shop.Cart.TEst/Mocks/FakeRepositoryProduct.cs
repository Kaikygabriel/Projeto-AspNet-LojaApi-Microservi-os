using System.Linq.Expressions;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Interfaces.Product;

namespace Shop.Cart.TEst.Mocks;

public class FakeRepositoryProduct : IProductRepository
{
    public FakeRepositoryProduct()
    {
        _products.AddRange(MockITems.MouseErgonomico,MockITems.NotebookGamer,MockITems.TecladoMecanico);
    }
    private List<Product> _products = new ();
    public async Task<IEnumerable<Product>> GetAll()
    {
        await Task.Delay(0);
        return _products;
    }

    public async Task<Product> GetByPredicate(Expression<Func<Product, bool>> predicate)
    {
        await Task.Delay(0);
        return _products.AsQueryable().FirstOrDefault(predicate);
    }

    public void Create(Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Add(entity);
    }

    public void Update(Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Add(entity);
    }

    public void Delete(Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Remove(entity);
    }
}