using Microsoft.AspNetCore.Mvc;
using Shop.Web.Cart.Services;
using Shop.Web.Models;
using Shop.Web.User.Models;
using Shop.Web.User.Service;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    private readonly CartService _cartService;
    private readonly ServiceAuth _auth;

    public AuthController(ServiceAuth auth, CartService cartService)
    {
        _auth = auth;
        _cartService = cartService;
    }

    [HttpGet("Cadastro")]
    public IActionResult Cadastro()
    {
        if (!ValidateUserConnect())
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> Cadastro(UserCadastro user)
    {
        try
        {
        if (!ModelState.IsValid || user is null)
            return View(user);

        var model = await _auth.Cadastro(user);
        if (model.Token is null)
            return View("Error");
        var userInfo = await _auth.GetUserOfToken(model.Token);
        model.user = userInfo;
        var createCart = await _cartService.CreateCart
            (new Cart.Models.Cart(model.user.Id.ToString()), model.Token);
        InsertInformationTokenInCookie(model);

        return RedirectToAction("Index", "Home");
     }
     catch(Exception e )
        {
            return View("Error");

        }
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (!ValidateUserConnect())
            return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(Userlogin user)
    {
        try
        {
            if (!ModelState.IsValid || user is null)
                return View(user);
            var model = await _auth.Login(user);
            if (model is null)
                return View("Error");
            if (model.Token is null)
                return View("Error");
            var userInfo = await _auth.GetUserOfToken(model.Token);
            model.user = userInfo;

            InsertInformationTokenInCookie(model);

            return RedirectToAction("Index", "Home");
        }
        catch(Exception e )
        {
            return View("Error");

        }
    }
    
    private void InsertInformationTokenInCookie(UserToken model)
    {
        var cookieOptions = new CookieOptions()
        {
            Expires = DateTime.UtcNow.AddDays(3),
            SameSite = SameSiteMode.Strict,
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("Token-Auth", model.Token, cookieOptions);
        Response.Cookies.Append("Email-User", model.user.Email, cookieOptions);
        Response.Cookies.Append("Id", model.user.Id.ToString(), cookieOptions);
    }

    private bool ValidateUserConnect()
    {
        var user = Request.Cookies["Email-User"];
        var token = Request.Cookies["Token-Auth"];
        var id = Request.Cookies["Id"];
        if (token is not null || user is not null|| id is not null)
            return false;
        return true;
    }
}