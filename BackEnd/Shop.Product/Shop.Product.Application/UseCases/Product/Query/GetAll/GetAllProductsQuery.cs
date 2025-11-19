using MediatR;

namespace Shop.Application.UseCases.Product.Query.GetAll;

public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>;