using MediatR;
using Shop.Application.DTOs.Category;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Category.Query.GetByName;

public class GetByNameCategoryHandler : HandlerBase,IRequestHandler<GetByNameCategoryQuery,Domain.Entities.Category>
{
    public GetByNameCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Domain.Entities.Category> Handle(GetByNameCategoryQuery request, CancellationToken cancellationToken)
    {
        return await UnitOfWork.RepositoryCategory.GetByPredicate(x => x.Name == request.Name);
    }
}