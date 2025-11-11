using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Category.Command.Delete;

public class DeleteCategoryHandler : HandlerBase, IRequestHandler<DeleteCategoryCommand,bool>
{
    public DeleteCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UnitOfWork.RepositoryCategory.Delete(request.Category);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}