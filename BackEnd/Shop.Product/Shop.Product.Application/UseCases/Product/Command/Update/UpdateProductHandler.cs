using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Update;

public class UpdateProductHandler :HandlerBase ,IRequestHandler<UpdateProductCommand,bool>
{
    public UpdateProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UnitOfWork.RepositoryProduct.Update(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }   
    }
}