using MediatR;

namespace Shop.Application.UseCases.Product.Command.Delete;

public record DeleteProductCommand(Domain.Entities.Product Product): IRequest<bool>;