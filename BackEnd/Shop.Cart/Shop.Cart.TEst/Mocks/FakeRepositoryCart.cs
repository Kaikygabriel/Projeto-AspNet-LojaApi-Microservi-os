using System.Linq.Expressions;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.TEst.Mocks;

public class FakeRepositoryCart : ICartRepository
{
    public FakeRepositoryCart()
    {
        _carts.Add(MockITems.CartMock);
    }
    private List<Cart.Domain.Entities.Cart> _carts = new(); 
    public async Task<IEnumerable<Cart.Domain.Entities.Cart>> GetAll()
    {
        await Task.Delay(0);
        return _carts;
    }

    public async Task<Cart.Domain.Entities.Cart> GetByPredicate(Expression<Func<Cart.Domain.Entities.Cart, bool>> predicate)
    {
        await Task.Delay(0);
        return _carts.AsQueryable().FirstOrDefault(predicate);
    }

    public void Create(Cart.Domain.Entities.Cart entity)
    {
        if (entity is null) throw new Exception();
        _carts.Add(entity);
    }

    public void Update(Cart.Domain.Entities.Cart entity)
    {
        if (entity is null) throw new Exception();
        _carts.Add(entity);
    }

    public void Delete(Cart.Domain.Entities.Cart entity)
    {
        if (entity is null) throw new Exception();
        _carts.Remove(entity);
    }
}