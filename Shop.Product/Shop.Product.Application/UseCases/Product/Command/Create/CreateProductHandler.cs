using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Create;

public class CreateProductHandler :HandlerBase ,IRequestHandler<CreateProductCommand,bool>
{
    public CreateProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var productExisting = 
                await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Product.Name); 
            if(productExisting is not null)
                return false;
                
            UnitOfWork.RepositoryProduct.Create(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }   
    }
}