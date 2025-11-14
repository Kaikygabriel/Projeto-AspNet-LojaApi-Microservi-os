using Mapster;
using MediatR;
using Shop.Application.DTOs.Category;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Category.Query.GetAll;

public class GetAllCategoryHandler : HandlerBase,
                    IRequestHandler<GetAllCategoryQuery,IEnumerable<Domain.Entities.Category>>
{
    public GetAllCategoryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<Domain.Entities.Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await UnitOfWork.RepositoryCategory.GetAllAsync();
    }
}