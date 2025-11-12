using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Product;

public class ProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImageUrl { get; set; }

    public Domain.Entities.Category Category { get; set; }

    public static explicit operator Domain.Entities.Product(ProductDto productDto)
        => new Domain.Entities.Product(
                productDto.Name, 
                productDto.Price,
                productDto.Stock,
                productDto.Description,
                productDto.ImageUrl); 

    public static explicit operator ProductDto(Domain.Entities.Product product)
        => new ProductDto
        {
            Name = product.Name,
            Description = product.Description,
            Category = product.Category,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Stock = product.Stock
        };
}