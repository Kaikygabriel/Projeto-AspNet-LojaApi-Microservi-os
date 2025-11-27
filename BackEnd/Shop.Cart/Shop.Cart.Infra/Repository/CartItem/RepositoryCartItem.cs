using Microsoft.EntityFrameworkCore;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Interfaces;
using Shop.Cart.Infra.Data.Context;

namespace Shop.Cart.Infra.Repository;

public class RepositoryCartItem : Repository<CartItem>,ICartItemRepository
{
    public RepositoryCartItem(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CartItem>> GetAllByIdUser(string userId)
    {
        return await _context.CartItems.AsNoTracking()
            .Include(x => x.Product)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}