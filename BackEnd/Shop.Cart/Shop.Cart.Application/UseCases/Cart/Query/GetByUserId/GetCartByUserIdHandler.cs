using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Entities;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Query.GetByUserId;

public class GetCartByUserIdHandler : HandlerBase,IHandler<GetCartByUserIdQuery,IEnumerable<CartItem>>
{
    public GetCartByUserIdHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<CartItem>> HandleAsync(GetCartByUserIdQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var cart = await _unitOfWork.RepositoryCartItem.GetAllByIdUser(request.idUser);
        return cart;
    }//PRECISO ARRUMAR 
}