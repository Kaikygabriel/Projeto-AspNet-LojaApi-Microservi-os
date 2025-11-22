using System.Security.Claims;
using Shop.Auth.Models;

namespace Shop.Auth.Serviços.Interfaces;

public interface ITokenService
{
    string GerenateAcessToken(IEnumerable<Claim> claims,IConfiguration configuration);
    IEnumerable<Claim> GetClaimsOfUser(User user);
}