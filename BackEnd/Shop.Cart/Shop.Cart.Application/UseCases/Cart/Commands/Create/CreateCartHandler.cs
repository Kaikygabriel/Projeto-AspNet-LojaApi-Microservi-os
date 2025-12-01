using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.Create;

public class CreateCartHandler : HandlerBase,IHandler<CreateCartCommand,bool>
{ 
    public CreateCartHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
    public async Task<bool> HandleAsync(CreateCartCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            _unitOfWork.RepositoryCart.Create(request.Cart);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}