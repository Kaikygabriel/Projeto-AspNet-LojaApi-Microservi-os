using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Delete;

public class DeleteProductHandler : HandlerBase,
    IRequestHandler<DeleteProductCommand,bool>
{
    public DeleteProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UnitOfWork.RepositoryProduct.Delete(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}