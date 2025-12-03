using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Discont.Api.Extensions;

public static class AuthenticationExtesion
{
    public static IServiceCollection AddAuthenticationFromMicrosservices(this IServiceCollection service,IConfiguration configuration)
    {
        var rsa = RSA.Create();
        rsa.ImportFromPem(configuration["Jwt:SecretKey"]!);

        service.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new()
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new RsaSecurityKey(rsa)
            };
        });
        service.AddAuthorization();
        return service;
    }
}