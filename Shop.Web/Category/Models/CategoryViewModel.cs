using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Category.Models;

public class CategoryViewModel
{
    public int Id { get; set; }
    [Required]
    [StringLength(170,MinimumLength = 3)]
    public string Name { get; set; }
}