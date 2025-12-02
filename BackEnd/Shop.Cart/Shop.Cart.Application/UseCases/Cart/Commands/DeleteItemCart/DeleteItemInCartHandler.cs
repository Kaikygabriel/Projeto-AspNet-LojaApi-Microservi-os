using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.DeleteItemCart;

public class DeleteItemInCartHandler : HandlerBase,IHandler<DeleteItemInCartCommand,bool>
{
    public DeleteItemInCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(DeleteItemInCartCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var cartItem = await _unitOfWork.RepositoryCartItem.GetByPredicate(x => x.Id == request.IdCartItem);
            if (cartItem is null)
                return false;
            if (!cartItem.UserId.Equals(request.UserId))
                return false;
            
            _unitOfWork.RepositoryCartItem.Delete(cartItem);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}