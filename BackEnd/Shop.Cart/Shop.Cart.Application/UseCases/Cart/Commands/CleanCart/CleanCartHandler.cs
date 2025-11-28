using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.CleanCart;

public class CleanCartHandler : HandlerBase,IHandler<CleanCartCommand,bool>
{
    public CleanCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(CleanCartCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var cart = await _unitOfWork.RepositoryCart.GetByPredicate(x => x.Id == request.cartId);
            cart.CleanItems();
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