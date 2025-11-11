using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Categorys;
using Shop.Product.Infra.Data.Context;

namespace Shop.Product.Infra.Repositorys.Category;

public class RepositoryCategory : Repository<Domain.Entities.Category>,IRepositoryCategory
{
    public RepositoryCategory(AppDbContext context) : base(context)
    {
    }
}