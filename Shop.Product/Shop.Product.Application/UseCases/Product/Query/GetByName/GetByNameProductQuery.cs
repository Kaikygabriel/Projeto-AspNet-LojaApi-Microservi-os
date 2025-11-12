using MediatR;
using Shop.Application.DTOs.Product;

namespace Shop.Application.UseCases.Product.Query.GetByName;

public record GetByNameProductQuery(string Name) : IRequest<ProductDto?>;