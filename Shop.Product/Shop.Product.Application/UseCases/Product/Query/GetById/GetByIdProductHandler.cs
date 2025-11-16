using MediatR;
using Shop.Application.DTOs.Product;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Query.GetById;

public class GetByIdProductHandler :HandlerBase,IRequestHandler<GetByIdProductQuery,ProductDto?>
{
    public GetByIdProductHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<ProductDto?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Id == request.Id);
        return (ProductDto)product;
    }
}