using Shop.Cart.Domain.Interfaces;
using Shop.Cart.Domain.Interfaces.Product;

namespace Shop.Cart.TEst.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    public ICartRepository RepositoryCart { get; } = new FakeRepositoryCart();
    public ICartItemRepository RepositoryCartItem { get; } = new FakeRepositoryCartItem();
    public IProductRepository RepositoryProduct { get; } = new FakeRepositoryProduct();
    public async  Task CommitAsync()
    {
        await Task.Delay(0);
    }
}