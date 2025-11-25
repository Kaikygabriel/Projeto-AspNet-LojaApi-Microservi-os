using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Shop.Auth.Models;
using Shop.Auth.Serviços.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Shop.Auth.Serviços;

public class TokenService : ITokenService
{


    public string GerenateAcessToken(IEnumerable<Claim> claims, IConfiguration configuration)
    {
        var key = configuration["Jwt:SecretKey"]!;
        var rsa = RSA.Create();
        rsa.ImportFromPem(key);
        
        var credentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Audience = configuration["Jwt:Audience"],
            Issuer = configuration["Jwt:Issuer"],
            Expires = DateTime.UtcNow.AddDays(3),
            Subject = new ClaimsIdentity(claims)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public IEnumerable<Claim> GetClaimsOfUser(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email.Address),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        foreach (var role in user.GetRoles())
         claims.Add(new Claim(ClaimTypes.Role,role));
        return claims;
    }

    public ClaimsPrincipal GenerateClaimsPrincipalOfToken(string token , IConfiguration configuration)
    {
        var key = configuration["Jwt:SecretKey"]!;
        var rsa = RSA.Create();
        rsa.ImportFromPem(key);

        
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = tokenHandler.ValidateToken(token,new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new RsaSecurityKey(rsa)
        },out var Jwttoken);
        if (Jwttoken is not JwtSecurityToken)
            return null;
        return claims;
    }
}