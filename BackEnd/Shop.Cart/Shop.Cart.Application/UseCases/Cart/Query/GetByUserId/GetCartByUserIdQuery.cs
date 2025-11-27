using MediatorX.Core.Abstraction.Interfaces;
using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Application.UseCases.Cart.Query.GetByUserId;

public record GetCartByUserIdQuery(string idUser) :IRequest<IEnumerable<CartItem>>;