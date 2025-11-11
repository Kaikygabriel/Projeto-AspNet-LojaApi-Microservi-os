using Shop.Domain.Interfaces.Products;
using Shop.Product.Infra.Data.Context;

namespace Shop.Product.Infra.Repositorys.Product;

public class RepositoryProduct : Repository<Domain.Entities.Product>,IRepositoryProduct
{
    public RepositoryProduct(AppDbContext context) : base(context)
    {
    }
}