using MediatR;

namespace Shop.Application.UseCases.Category.Command.Update;

public record UpdateCategoryCommand(Domain.Entities.Category Category):IRequest<bool>;