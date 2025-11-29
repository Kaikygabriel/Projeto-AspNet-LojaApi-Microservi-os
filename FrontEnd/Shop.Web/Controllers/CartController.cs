using Microsoft.AspNetCore.Mvc;
using Shop.Web.Cart.Models;
using Shop.Web.Cart.Services;
using Shop.Web.Products.Models;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        var token = GetTokenOfCookie();
        var userId = GetUserIdOfCookie();
        if (!VerifyAuthentication())
            return RedirectToAction("Cadastro","Auth");
        var cartItems = await _cartService.GetCartItemByUserIdOrNull(userId, token);
        return View(cartItems);
    }
    [HttpPost("AddCartItem")]
    public async Task<IActionResult> AddItemInCart(ProductViewModel product)
    {
        var token = GetTokenOfCookie();
        var userId = GetUserIdOfCookie();
       if (!VerifyAuthentication())
          return RedirectToAction("Cadastro","Auth");
        var cartItem = new CartItem()
        {
            UserId = userId,
            Product = product,
            ProductId = product.Id,
            Quantity = 1
        };
        var result = await _cartService.AddItem(cartItem, userId, token);
        return result ? RedirectToAction("Index", "Cart"): View("Error");
    }
    [HttpPost("DeleteItem")]
    public async Task<IActionResult> DeleteItemInCart([FromQuery]int id)
    {
        var token = GetTokenOfCookie();
        var userId = GetUserIdOfCookie();
        if (!VerifyAuthentication())
            return RedirectToAction("Cadastro","Auth");
        var result = await _cartService.RemoveItem(id, userId, token);
        return result ? RedirectToAction("Index", "Products"): View("Error");
    }
        
    private string? GetTokenOfCookie()
    {
        return Request.Cookies["Token-Auth"];
    }
    private string? GetUserIdOfCookie()
    {
        return Request.Cookies["Id"];
    }

    private bool VerifyAuthentication()
    {
        var token = GetTokenOfCookie();
        var userId = GetUserIdOfCookie();
        if (token is null || userId is null )
            return false;
        return true;
    }
}