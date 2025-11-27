using MediatorX.Core.Abstraction.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Commands.DeleteItemCart;

public record DeleteItemInCartCommand(int IdCartItem,string UserId) : IRequest<bool>;