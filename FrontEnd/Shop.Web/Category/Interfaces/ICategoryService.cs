using Shop.Web.Category.Models;
using Shop.Web.Models;

namespace Shop.Web.Category.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllAsync();
}