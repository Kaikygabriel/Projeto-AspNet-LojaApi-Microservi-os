using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Category.Interfaces;
using Shop.Web.Models;
using Shop.Web.Products.Interfaces;
using Shop.Web.Products.Models;
using Shop.Web.User.Service;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ServiceAuth _authService;
    private readonly IProductService _productService;

    public ProductsController(IProductService productService, ICategoryService categoryService, ServiceAuth authService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _authService = authService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var token = GetTokenOfCookie();
        var userAdmin = await IsUserAdmin(token);
        ViewBag.UserAdmin = userAdmin;
        ViewBag.EmailUser = Request.Cookies["Email-User"];
        var products = await _productService.GetAllAsync();
        if(products is null) return View("Error");
        return View(products);
    }
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetById(id);
        if (product is null)
            return NotFound();
        return View(product);
    }
    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
        var token = GetTokenOfCookie();
        ViewBag.Categorys = new SelectList(await _categoryService.GetAllAsync(token),
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
        
        return resultCreate? RedirectToAction("Index","Home") : View(model) ;
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

    private async Task<bool> IsUserAdmin(string token)
    {
        if (token is null)
            return false;
        var user =await _authService.GetUserOfToken(token);
        if (user.Roles.FirstOrDefault(x=>x == "Admin") is null)
            return false;
        return true;
    }
}