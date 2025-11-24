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
        var token = GetTokenOfCookie();
        if(token is null)
            return RedirectToAction("Cadastro", "Auth");
        var categorys = await _categoryService.GetAllAsync(token);
        if (categorys is null)
            return View("Error");

        return View(categorys);
    }
    private string? GetTokenOfCookie()
    {
        return Request.Cookies["Token-Auth"];

    }
}