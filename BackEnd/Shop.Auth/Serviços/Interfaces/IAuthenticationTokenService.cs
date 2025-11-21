namespace Shop.Auth.Serviços.Interfaces;

public interface IAuthenticationTokenService
{
    string GenerateAuthenticationToken(string email);
    string GenerateAccessToken(string authenticationCode);

}