using MediatR;

namespace Shop.Application.UseCases.Category.Command.Delete;

public record DeleteCategoryCommand(Domain.Entities.Category Category):IRequest<bool>;