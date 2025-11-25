using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Auth.Models;
using Shop.Auth.Serviços.Interfaces;
using Shop.Authh.DTOs;

namespace Shop.Auth.Controllers;


[Route("[controller]")]
public class AuthController  : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserManager _userManager;
    private readonly IAuthenticationTokenService _serviceAuth;


    public AuthController(ITokenService tokenService, IUserManager userManager, IAuthenticationTokenService serviceAuth)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _serviceAuth = serviceAuth;
    }

    [HttpPost("Cadastro")]
     public async Task<ActionResult> Cadastro([FromBody]UserCadastro userCadastro)
     {
         if (userCadastro is null )
             return BadRequest("User is invalid");
         User user = userCadastro;
         var result =  await _userManager.CreateUser(user);
         if (!result)
             return BadRequest("Error in creating user!");
         var code = _serviceAuth.GenerateAuthenticationToken(user.Email.Address);
         return Ok(code);
     }
     
    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody]UserLogin userLogin)
    {
        if (userLogin is null )
            return BadRequest("User is invalid");
        User user = await _userManager.FindUserByEmail(userLogin.Email);

        if (user is null || !_userManager.CheckPassword(user, userLogin.Password))
            return NotFound("Password invalid or user is null");
        
        var code = _serviceAuth.GenerateAuthenticationToken(user.Email.Address);
        return Ok(code);
    }
    [HttpPost("CodeAuthentication")]
    public async Task<ActionResult> LoginCodeAuthentication([FromBody]string codeAuthentication)
    {
        if(codeAuthentication is null)
            return BadRequest("");
        var token = await _serviceAuth.GenerateAccessToken(codeAuthentication);

        if (token is null)
            return BadRequest("");
        
        return Ok(token);
    }
    [HttpPost("InfoUser")]
    public ActionResult GetInfoUser([FromBody]string token)
    {
        if(token is null)
            return BadRequest("");
        var user  = _serviceAuth.GetUserFromToken(token);

        if (user is null)
            return BadRequest("");
        
        return Ok(user);
    }
 }