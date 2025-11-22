namespace Shop.Auth.Serviços.Interfaces;

public interface IAuthenticationTokenService
{
    string GenerateAuthenticationToken(string email);
    Task<string> GenerateAccessToken(string authenticationCode);

}