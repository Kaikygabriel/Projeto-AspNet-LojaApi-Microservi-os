using MediatorX.Core.Abstraction.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.CleanCart;

public record CleanCartCommand(int cartId) : IRequest<bool>;