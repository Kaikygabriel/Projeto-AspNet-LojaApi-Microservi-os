using System.Linq.Expressions;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.TEst.Mocks;

public class FakeRepositoryCartItem : ICartItemRepository
{

    private List<CartItem> CartItems = new ()
    {
        MockITems.MouseItem,
        MockITems.NotebookItem,
        MockITems.TecladoItem
    };
    public async Task<IEnumerable<CartItem>> GetAll()
    {
        await Task.Delay(0);
        return CartItems;
    }

    public async Task<CartItem> GetByPredicate(Expression<Func<CartItem, bool>> predicate)
    {
        await Task.Delay(0);
        return CartItems.AsQueryable().FirstOrDefault(predicate);
    }

    public void Create(CartItem entity)
    {
        if (entity is null)
            throw new Exception();
        CartItems.Add(entity);
    }

    public void Update(CartItem entity)
    {
        if (entity is null)
            throw new Exception();
        CartItems.Add(entity);
    }

    public void Delete(CartItem entity)
    {
        if (entity is null)
            throw new Exception();
        CartItems.Remove(entity);
    }

    public async Task<IEnumerable<CartItem>> GetAllByIdUser(string userId)
    {
        await Task.Delay(0);
        return CartItems.Where(x=>x.UserId == userId);
    }
}