using System.Linq.Expressions;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Interfaces;
using Shop.Cart.Domain.Interfaces.Product;
using Shop.Cart.Infra.Data.Context;
using Shop.Cart.Infra.Repository.Product;

namespace Shop.Cart.Infra.Repository;

public class UnitOfWork : IUnitOfWork
{
    private RepositoryCart _repositoryCart;
    private RepositoryProduct _repositoryProduct;
    private RepositoryCartItem _repositoryCartItem;

    
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICartRepository RepositoryCart
    {
        get
        {
            return _repositoryCart = _repositoryCart?? new (_context);
        }
    }

    public ICartItemRepository RepositoryCartItem
    {
        get
        {
            return _repositoryCartItem = _repositoryCartItem?? new (_context);

        }
    }

    public IProductRepository RepositoryProduct
    {
        get
        {
            return _repositoryProduct = _repositoryProduct?? new (_context);

        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}