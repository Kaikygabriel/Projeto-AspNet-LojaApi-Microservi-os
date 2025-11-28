using Shop.Auth.Models;
using Shop.Authh.DTOs;

namespace Shop.Auth.Serviços.Interfaces;

public interface IAuthenticationTokenService
{
    string GenerateAuthenticationToken(string email);
    Task<string> GenerateAccessToken(string authenticationCode);
    Task<UserInfo> GetUserFromToken(string token);
}