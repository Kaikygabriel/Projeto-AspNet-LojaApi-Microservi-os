using Shop.Web.Models;

namespace Shop.Web.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetById(int id);
    Task<bool> Create(ProductViewModel product);
    Task<bool> Delete(string name);
}