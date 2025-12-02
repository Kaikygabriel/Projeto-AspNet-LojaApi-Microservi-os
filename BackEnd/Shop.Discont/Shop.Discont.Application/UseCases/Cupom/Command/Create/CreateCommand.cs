using MediatR;

namespace Shop.Discont.Application.UseCases.Cupom.Command.Create;

public record CreateCommand(Domain.BackOffice.Entitites.Cupom Cupom) : IRequest<bool>;
