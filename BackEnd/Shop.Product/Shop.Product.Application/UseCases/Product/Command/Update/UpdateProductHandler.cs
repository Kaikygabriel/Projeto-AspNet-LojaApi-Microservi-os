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
            var userExisting =await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Product.Name);
            if (userExisting is null)
                return false;
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