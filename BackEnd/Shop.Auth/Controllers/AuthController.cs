using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Shop.Auth.Models;
using Shop.Auth.Serviços.Interfaces;

namespace Shop.Auth.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    private IAuthenticationTokenService _tokenServiceAuthetencation;
    private IUserManager _userManager;

    public AuthController(IUserManager userManager, IAuthenticationTokenService tokenServiceAuthetencation)
    {
        _userManager = userManager;
        _tokenServiceAuthetencation = tokenServiceAuthetencation;
    }

    [HttpGet("login-google")]
    public IActionResult LoginGoogle()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("signin")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

        if (!result.Succeeded)
            return BadRequest("Falha ao autenticar via Google.");

        var principal = result.Principal;

        var userData = CreateUserForClaims(principal);
        
        if (userData.Email.Address is null)
         return BadRequest("Email não encontrado na conta Google."); 
        //ja verifica se existe um usuario 
        var response = await _userManager.CreateUser(userData);

        if (!response)
            return BadRequest("Falha ao criar usuario");

        var codeAuthentication = _tokenServiceAuthetencation.GenerateAuthenticationToken(userData.Email.Address);
        
        return Ok(codeAuthentication);
    }

    private User CreateUserForClaims(ClaimsPrincipal claims)
    {
        return new 
            User(claims.FindFirst(ClaimTypes.Name)?.Value, claims.FindFirst(ClaimTypes.Email)?.Value
        );
    }
}