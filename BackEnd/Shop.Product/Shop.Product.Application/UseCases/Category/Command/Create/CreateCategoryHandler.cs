using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Category.Command.Create;

public class CreateCategoryHandler : HandlerBase, IRequestHandler<CreateCategoryCommand,bool>
{
    public CreateCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UnitOfWork.RepositoryCategory.Create(request.Category);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}