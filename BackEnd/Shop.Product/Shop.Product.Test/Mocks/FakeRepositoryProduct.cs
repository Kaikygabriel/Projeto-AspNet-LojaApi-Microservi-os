using System.Linq.Expressions;
using Shop.Domain.Interfaces.Products;

namespace Shop.Product.Test.Mocks;

public class FakeRepositoryProduct : IRepositoryProduct
{
    private List<Shop.Domain.Entities.Product> _products = new()
    {
        new Shop.Domain.Entities.Product(
            name: "Notebook Dell Inspiron 15",
            price: 4500.00m,
            stock: 15,
            description: "Notebook Dell com processador Intel Core i5, 8GB RAM e SSD de 256GB.",
            imageUrl: "https://example.com/images/notebook-dell.jpg",1
        )
        {
            Id  = 1
        },
        new Shop.Domain.Entities.Product(
            name: "Smartphone Samsung Galaxy S23",
            price: 3799.99m,
            stock: 20,
            description: "Smartphone Samsung com tela AMOLED de 6.1'' e câmera tripla de 50MP.",
            imageUrl: "https://example.com/images/galaxy-s23.jpg",1
        ),
        new Shop.Domain.Entities.Product(
            name: "Fone de Ouvido Bluetooth JBL Tune 510BT",
            price: 299.90m,
            stock: 50,
            description: "Fone de ouvido sem fio JBL com bateria de até 40 horas e carregamento rápido.",
            imageUrl: "https://example.com/images/jbl-510bt.jpg",1
        )
    };
    public Task<IEnumerable<Shop.Domain.Entities.Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Shop.Domain.Entities.Product>>(_products);
    }

    public Task<Shop.Domain.Entities.Product> GetByPredicate(Expression<Func<Shop.Domain.Entities.Product, bool>> predicate)
    {
        return Task.FromResult<Shop.Domain.Entities.Product>(
            _products.AsQueryable().FirstOrDefault(predicate));
    }

    public void Create(Shop.Domain.Entities.Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Add(entity);
    }

    public void Update(Shop.Domain.Entities.Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Add(entity);
    }

    public void Delete(Shop.Domain.Entities.Product entity)
    {
        if (entity is null)
            throw new Exception();
        _products.Remove(entity);
    }
}