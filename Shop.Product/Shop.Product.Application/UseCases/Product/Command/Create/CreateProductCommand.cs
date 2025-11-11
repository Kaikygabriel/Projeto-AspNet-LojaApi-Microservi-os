using MediatR;

namespace Shop.Application.UseCases.Product.Command.Create;

public record CreateProductCommand(Domain.Entities.Product Product):  IRequest<bool>;