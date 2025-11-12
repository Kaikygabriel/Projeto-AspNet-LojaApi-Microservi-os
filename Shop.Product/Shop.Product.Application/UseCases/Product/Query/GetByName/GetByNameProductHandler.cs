using MediatR;
using Shop.Application.DTOs.Product;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Query.GetByName;

public class GetByNameProductHandler :HandlerBase,IRequestHandler<GetByNameProductQuery,ProductDto?>
{
    public GetByNameProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<ProductDto?> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
    {
        return (ProductDto)await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Name);
    }
}