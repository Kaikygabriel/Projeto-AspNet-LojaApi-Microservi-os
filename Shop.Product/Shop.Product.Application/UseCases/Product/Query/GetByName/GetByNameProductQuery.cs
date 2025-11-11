using MediatR;

namespace Shop.Application.UseCases.Product.Query.GetByName;

public record GetByNameProductQuery(string Name) : IRequest<Domain.Entities.Product>;