using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Domain.Interfaces;

public interface ICartItemRepository : IRepository<CartItem>
{
    Task<IEnumerable<CartItem>> GetAllByIdUser(string userId);
}