using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Categorys;
using Shop.Domain.Interfaces.Products;
using Shop.Product.Infra.Data.Context;
using Shop.Product.Infra.Repositorys.Category;
using Shop.Product.Infra.Repositorys.Product;

namespace Shop.Product.Infra.Repositorys;

public class UnitOfWork : IUnitOfWork
{
    private RepositoryProduct _repositoryProduct;
    private RepositoryCategory _repositoryCategory;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepositoryCategory RepositoryCategory
    {
        get
        {
            return _repositoryCategory ??= new RepositoryCategory(_context);
        }
    }

    public IRepositoryProduct RepositoryProduct
    {
        get
        {
            return _repositoryProduct ??= new RepositoryProduct(_context);
        }
    }

    public async Task CommitAsync()
    { 
        await _context.SaveChangesAsync();
    }
}