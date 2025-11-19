using Shop.Domain.Entities.Abstraction;
using Shop.Domain.Exceptions;

namespace Shop.Domain.Entities;

public class Category : Entity
{
    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            throw new CategoryException("Error in name of constructor Category!");  
        Name = name;
    }

    public string Name { get; set; }
    public ICollection<Product>Products { get; set; }
}