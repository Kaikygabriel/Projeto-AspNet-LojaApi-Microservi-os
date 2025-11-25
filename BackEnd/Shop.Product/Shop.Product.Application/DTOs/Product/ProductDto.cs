using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Product;

public class ProductDto
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] public int Stock { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string ImageUrl { get; set; }
	
    [Required] public int IdCategory { get; set; }

    public static explicit operator Domain.Entities.Product(ProductDto? productDto)
    {
        if (productDto is null)
            return null;
        return new Domain.Entities.Product(
            productDto.Name,
            productDto.Price,
            productDto.Stock,
            productDto.Description,
            productDto.ImageUrl,
            productDto.IdCategory);
        }

    public static explicit operator ProductDto(Domain.Entities.Product? product)
    {
        if (product is null)
            return null;
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Stock = product.Stock,
            IdCategory = product.IdCategory
        };
    }
}