using MediatR;
using Shop.Application.DTOs.Product;

namespace Shop.Application.UseCases.Product.Query.GetById;

public record GetByIdProductQuery(int Id) : IRequest<ProductDto?>;