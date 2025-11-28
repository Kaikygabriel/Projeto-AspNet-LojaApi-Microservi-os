using Shop.Cart.Domain.Interfaces.Product;

namespace Shop.Cart.Domain.Interfaces;

public interface IUnitOfWork 
{
    public ICartRepository RepositoryCart{ get; }
    public ICartItemRepository RepositoryCartItem{ get; }
    public IProductRepository RepositoryProduct{ get; }

    Task CommitAsync();
}