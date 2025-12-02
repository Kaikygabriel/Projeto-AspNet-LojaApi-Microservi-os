using MediatR;

namespace Shop.Discont.Application.UseCases.Cupom.Query.GetByName;

public record GetByNameQuery(string Name) : IRequest<Domain.BackOffice.Entitites.Cupom?>;
