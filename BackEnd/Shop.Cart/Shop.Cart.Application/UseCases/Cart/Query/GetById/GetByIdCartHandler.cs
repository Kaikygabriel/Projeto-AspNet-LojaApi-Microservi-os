using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Query.GetById;

public class GetByIdCartHandler : HandlerBase,IHandler<GetByIdCartQuery,Domain.Entities.Cart>
{
    public GetByIdCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Domain.Entities.Cart> HandleAsync(GetByIdCartQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var cart = await _unitOfWork.RepositoryCart.GetByPredicate(x => x.Id == request.Id);
        return cart;
    }
}