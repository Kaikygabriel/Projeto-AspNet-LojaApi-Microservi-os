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
        return View();
    }
    [HttpPost("Cadastro")]
    public async Task<IActionResult> Cadastro(UserCadastro user)
    {
        if (!ModelState.IsValid || user is null)
            return View(user);
        
        var token = await _auth.Cadastro(user);
        if (token is null)
            return View("Error");
        
        InsertInformationTokenInCookie(token);
        
        return RedirectToAction("Index", "Home");
    }

    private void InsertInformationTokenInCookie(string model)
    {
        var cookieOptions = new CookieOptions()
        {
            Expires = DateTime.UtcNow.AddDays(3),
            SameSite = SameSiteMode.Strict,
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("Token-Auth", model, cookieOptions);
    }
}