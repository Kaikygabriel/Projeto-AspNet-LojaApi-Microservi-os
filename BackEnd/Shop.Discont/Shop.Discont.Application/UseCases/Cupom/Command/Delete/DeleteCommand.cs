using MediatR;

namespace Shop.Discont.Application.UseCases.Cupom.Command.Delete;

public record DeleteCommand(int Id) : IRequest<bool>;