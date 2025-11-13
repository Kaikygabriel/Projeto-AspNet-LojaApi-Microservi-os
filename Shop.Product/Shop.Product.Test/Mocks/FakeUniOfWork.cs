using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Categorys;
using Shop.Domain.Interfaces.Products;

namespace Shop.Product.Test.Mocks;

public class FakeUniOfWork : IUnitOfWork
{
    public IRepositoryCategory RepositoryCategory { get; } = new FakeRepositoryCategory();
    public IRepositoryProduct RepositoryProduct { get; } = new FakeRepositoryProduct();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}