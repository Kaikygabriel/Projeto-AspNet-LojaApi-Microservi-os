using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Category.Command.Update;

public class UpdateCategoryHandler : HandlerBase, IRequestHandler<UpdateCategoryCommand,bool>
{
    public UpdateCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UnitOfWork.RepositoryCategory.Update(request.Category);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}