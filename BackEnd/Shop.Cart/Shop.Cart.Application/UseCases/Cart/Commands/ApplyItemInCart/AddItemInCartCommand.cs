using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Application.UseCases.Cart.Commands.ApplyItemInCart;

public record AddItemInCartCommand(CartItem CartItem, string UserId) :  IRequest<bool>;