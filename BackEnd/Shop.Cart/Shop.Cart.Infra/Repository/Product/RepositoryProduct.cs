using Shop.Cart.Domain.Interfaces.Product;
using Shop.Cart.Infra.Data.Context;

namespace Shop.Cart.Infra.Repository.Product;

public class RepositoryProduct : Repository<Domain.Entities.Product>,IProductRepository
{
    public RepositoryProduct(AppDbContext context) : base(context)
    {
    }
    
}