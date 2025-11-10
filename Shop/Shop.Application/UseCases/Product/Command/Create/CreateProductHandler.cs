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