using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using Shop.Web.User.Models;
using Shop.Web.User.Service;

namespace Shop.Web.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    private readonly ServiceAuth _auth;

    public AuthController(ServiceAuth auth)
    {
        _auth = auth;
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
        if (!ModelState.IsValid || user is null)
            return View(user);
        
        var model = await _auth.Cadastro(user);
        if (model.Token is null)
            return View("Error");
        
        InsertInformationTokenInCookie(model);
        
        return RedirectToAction("Index", "Home");
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
        if (!ModelState.IsValid || user is null)
            return View(user);
        var model = await _auth.Login(user);
        if (model.Token is null)
            return View("Error");
        
        InsertInformationTokenInCookie(model);
        
        return RedirectToAction("Index", "Home");
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
        Response.Cookies.Append("Email-User", model.Email, cookieOptions);
    }

    private bool ValidateUserConnect()
    {
        var user = Request.Cookies["Email-User"];
        var token = Request.Cookies["Token-Auth"];
        if (token is not null || user is not null)
            return false;
        return true;
    }
}