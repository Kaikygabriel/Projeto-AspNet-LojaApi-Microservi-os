using MediatR;
using Shop.Application.DTOs.Category;

namespace Shop.Application.UseCases.Category.Query.GetByName;

public record GetByNameCategoryQuery(string Name) :IRequest<Domain.Entities.Category>;