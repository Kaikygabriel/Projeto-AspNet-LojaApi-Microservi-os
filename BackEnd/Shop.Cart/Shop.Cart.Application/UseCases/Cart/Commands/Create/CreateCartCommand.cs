using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Application.UseCases.Cart.Commands.Create;

public record CreateCartCommand(Domain.Entities.Cart Cart) : IRequest<bool>;