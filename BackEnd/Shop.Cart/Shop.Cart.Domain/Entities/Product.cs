
using Shop.Cart.Domain.ObjectValues;

namespace Shop.Cart.Domain.Entities;

public class Product : Entity
{
    public Product()
    {
        
    }
    public Product(string name, decimal price, int stock, string description, string? imageUrl)
    {
        Validate(name, price, imageUrl, description);
        
        Name = name;
        Price = price;
        Stock = stock;
        Description = description;
        ImageUrl = imageUrl;
    }

    public string Name { get; set; }
    public decimal Price{ get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    

    
    private void Validate(string name, decimal price,string imageUrl, string description)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 1 ||
            string.IsNullOrWhiteSpace(description) || description.Length < 2 ||
            string.IsNullOrWhiteSpace(imageUrl) || imageUrl.Length < 2 ||
            price < 1)
            throw new System.Exception("Error in parameters of Product");
    }
}