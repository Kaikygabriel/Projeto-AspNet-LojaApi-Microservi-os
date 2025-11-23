using Shop.Web.Models;
using Shop.Web.Products.Models;

namespace Shop.Web.Products.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync(string token);
    Task<ProductViewModel> GetById(int id,string token);
    Task<bool> Create(ProductViewModel product,string token);
    Task<bool> Delete(int id,string token);
}