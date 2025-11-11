using MediatR;

namespace Shop.Application.UseCases.Category.Query.GetByName;

public record GetByNameCategoryQuery(string Name) :  IRequest<Domain.Entities.Category>;