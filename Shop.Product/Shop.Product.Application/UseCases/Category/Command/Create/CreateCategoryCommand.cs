using MediatR;

namespace Shop.Application.UseCases.Category.Command.Create;

public record CreateCategoryCommand(Domain.Entities.Category Category):IRequest<bool>;