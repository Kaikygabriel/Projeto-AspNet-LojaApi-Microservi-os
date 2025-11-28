using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Products.Models;

public class ProductViewModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(170,MinimumLength = 3)]
    public string? Name { get; set; }
    [Required]
    public decimal Price{ get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    [Required]
    public int IdCategory { get; set; }

}