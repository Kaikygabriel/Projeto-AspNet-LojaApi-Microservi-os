using Microsoft.AspNetCore.Mvc;
using Shop.Web.Category.Interfaces;

namespace Shop.Web.Controllers;

public class CategorysController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategorysController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var categorys = await _categoryService.GetAllAsync();
        if (categorys is null)
            return View("Error");

        return View(categorys);
    }
}