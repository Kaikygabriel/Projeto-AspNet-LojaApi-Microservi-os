using MediatR;

namespace Shop.Application.UseCases.Product.Command.Update;

public record UpdateProductCommand(Domain.Entities.Product Product):  IRequest<bool>;