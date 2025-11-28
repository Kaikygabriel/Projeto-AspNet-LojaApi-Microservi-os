using Shop.Web.Models;
using Shop.Web.Products.Models;

namespace Shop.Web.Products.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<ProductViewModel> GetById(int id);
    Task<bool> Create(ProductViewModel product,string token);
    Task<bool> Delete(int id,string token);
}