using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Cart.Domain.Interfaces;
using Shop.Cart.Infra.Data.Context;

namespace Shop.Cart.Infra.Repository;

public class RepositoryCart: Repository<Domain.Entities.Cart>,ICartRepository
{
    public RepositoryCart(AppDbContext context) : base(context)
    {
    }
    
}