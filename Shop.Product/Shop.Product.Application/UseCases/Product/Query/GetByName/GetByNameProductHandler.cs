using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Query.GetByName;

public class GetByNameProductHandler :HandlerBase,IRequestHandler<GetByNameProductQuery,Domain.Entities.Product>
{
    public GetByNameProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Domain.Entities.Product> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
    {
        return await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Name);
    }
}