using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Product.Api.Extensions.JwtIncrement;

public static class AuthenticationJwtExtension
{
    public static void AddJwtAuthentication(this IServiceCollection services,IConfiguration configuration)
    {
        var keypublic = configuration["Jwt:SecretKey"]!;
        var rsa = RSA.Create();
        rsa.ImportFromPem(keypublic);
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = configuration["Jwt:Audience"],
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new RsaSecurityKey(rsa)
            };
        });
        services.AddAuthorization();
    } 
}