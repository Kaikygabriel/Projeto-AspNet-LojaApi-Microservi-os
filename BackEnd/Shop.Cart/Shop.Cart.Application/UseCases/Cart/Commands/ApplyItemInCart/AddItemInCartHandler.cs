using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.ApplyItemInCart;

public class AddItemInCartHandler:HandlerBase,IHandler<AddItemInCartCommand,bool>
{
    public AddItemInCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(AddItemInCartCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var cart = await _unitOfWork.RepositoryCart.GetByPredicate(x => x.UserId == request.UserId);
            if (cart is null) return false;
            
            var product = await _unitOfWork.RepositoryProduct.GetByPredicate(x => x.Id == request.CartItem.ProductId);
            if (product is null) _unitOfWork.RepositoryProduct.Create(request.CartItem.Product);

            cart.AddItemsInCart(request.CartItem);

            _unitOfWork.RepositoryCartItem.Create(request.CartItem);
            _unitOfWork.RepositoryCart.Update(cart);

            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
//testess
//cartitme null e não null
//cart null e não null