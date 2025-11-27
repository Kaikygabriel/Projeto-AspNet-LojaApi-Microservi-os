using MediatorX.Core.Abstraction.Interfaces;

namespace Shop.Cart.Application.UseCases.Cart.Query.GetById;

public record GetByIdCartQuery(int Id): IRequest<Domain.Entities.Cart>;