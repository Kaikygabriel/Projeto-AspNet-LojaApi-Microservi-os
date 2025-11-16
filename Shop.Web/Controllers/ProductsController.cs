using Microsoft.AspNetCore.Mvc;
using Shop.Web.Services.Interfaces;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
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
}