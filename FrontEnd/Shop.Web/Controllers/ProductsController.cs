using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Category.Interfaces;
using Shop.Web.Models;
using Shop.Web.Products.Interfaces;
using Shop.Web.Products.Models;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly ICategoryService _categoryService;

    private readonly IProductService _productService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var token = GetTokenOfCookie();
        if (token is null)
            return RedirectToAction("Cadastro", "Auth");  
        var products = await _productService.GetAllAsync(token);
        if(products is null) return View("Error");
        return View(products);
    }
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var token = GetTokenOfCookie();
        if (token is null)
            return RedirectToAction("Cadastro", "Auth");
        var product = await _productService.GetById(id,token);
        if (product is null)
            return NotFound();
        return View(product);
    }
    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categorys = new SelectList(await _categoryService.GetAllAsync(),
            "Id","Name");
        return View();
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        if (!ModelState.IsValid || model is null)
            return View(model);
        var token = GetTokenOfCookie();
        if (token is null)
            return RedirectToAction("Cadastro", "Auth");
        var resultCreate = await _productService.Create(model,token);
        
        return resultCreate? Redirect($"Home/Index") : View(model) ;
    }
    [HttpGet("Delete")]
    public async Task<IActionResult> Delete()
    {
        return View();
    }
    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var token = GetTokenOfCookie();
        if (token is null)
            return RedirectToAction("Cadastro", "Auth");
        var resultCreate = await _productService.Delete(id,token);
        
        return resultCreate? Redirect($"Home/Index") : View("Error") ;
    }

    private string? GetTokenOfCookie()
    {
        return Request.Cookies["Token-Auth"];

    }
}