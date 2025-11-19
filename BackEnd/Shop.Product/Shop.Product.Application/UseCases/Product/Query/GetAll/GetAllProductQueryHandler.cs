using MediatR;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Query.GetAll;

public class GetAllProductQueryHandler : HandlerBase,
        IRequestHandler<GetAllProductsQuery,IEnumerable<Domain.Entities.Product>>
{
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        { 
            return await UnitOfWork.RepositoryProduct.GetAllAsync();
        }
}