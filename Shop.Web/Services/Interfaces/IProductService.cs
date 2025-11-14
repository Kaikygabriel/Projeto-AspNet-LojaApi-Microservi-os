using Shop.Web.Models;

namespace Shop.Web.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetByName(string name);
    bool Create(ProductViewModel product);
    bool Delete(string name);
}