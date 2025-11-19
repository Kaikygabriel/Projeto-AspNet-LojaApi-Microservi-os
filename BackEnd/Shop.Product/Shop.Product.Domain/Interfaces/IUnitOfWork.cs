using Shop.Domain.Interfaces.Categorys;
using Shop.Domain.Interfaces.Products;

namespace Shop.Domain.Interfaces;

public interface IUnitOfWork
{
    public IRepositoryCategory RepositoryCategory { get; }
    public IRepositoryProduct RepositoryProduct{ get;  }

    Task CommitAsync();
}