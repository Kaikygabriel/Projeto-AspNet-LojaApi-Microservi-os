using System.ComponentModel.DataAnnotations;
using Shop.Domain.Entities;

namespace Shop.Application.DTOs.Category;

public class CategoryDto
{
      [Required(ErrorMessage = "The name is required!")]
      [StringLength(120,MinimumLength = 3)]
      public string Name { get; set; }
      public ICollection<Domain.Entities.Product>Products { get; set; }
      
      public static  explicit operator Domain.Entities.Category(CategoryDto cateogoryDto)
      {
            return new Domain.Entities.Category
                  (cateogoryDto.Name)
                  {
                        Products = cateogoryDto.Products
                  };
      }  
      public static  explicit  operator CategoryDto (Domain.Entities.Category cateogory)
      {
            return new CategoryDto
            {
                  Name = cateogory.Name,
                  Products = cateogory.Products
            };
      }  
}