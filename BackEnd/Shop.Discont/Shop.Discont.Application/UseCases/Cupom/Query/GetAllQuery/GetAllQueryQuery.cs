using MediatR;

namespace Shop.Discont.Application.UseCases.Cupom.Query.GetAllQuery;

public record GetAllQuery() : IRequest<IEnumerable<Domain.BackOffice.Entitites.Cupom>>;
