using MediatR;
using Shop.Application.DTOs.Category;

namespace Shop.Application.UseCases.Category.Query.GetAll;

public record GetAllCategoryQuery : IRequest<IEnumerable<Domain.Entities.Category>>;