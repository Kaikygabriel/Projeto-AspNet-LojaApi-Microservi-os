using System.Text;
using System.Text.Json;
using Shop.Web.Models;
using Shop.Web.Products.Models;
using Shop.Web.User.Models;

namespace Shop.Web.User.Service;

public class ServiceAuth
{
    private const string ClientAuth = "AuthApi";
    private const string EndPointAPi = "Auth";
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    
    public ServiceAuth(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<UserToken> Cadastro(UserCadastro userCadastro)
    {
        var client = _clientFactory.CreateClient(ClientAuth);
        var user = JsonSerializer.Serialize(userCadastro);
        var stringContent = new StringContent(user,Encoding.UTF8,"application/json");
        using var response = await client.PostAsync($"{EndPointAPi}/Cadastro",stringContent);
        if (!response.IsSuccessStatusCode)
            return null;
        var responseApi =await response.Content.ReadAsStreamAsync();
        var codeAuthorization = JsonSerializer.Deserialize<string>(responseApi,_jsonSerializerOptions);

        var token = await GetAccessTokenOfAuthenticationCode(codeAuthorization);
        
        var modelReturn = new UserToken { Token = token};
        return modelReturn;
    }
    public async Task<UserToken> Login(Userlogin user)
        {
            var client = _clientFactory.CreateClient(ClientAuth);
            var userJson = JsonSerializer.Serialize(user);
            var stringContent = new StringContent(userJson,Encoding.UTF8,"application/json");
            using var response = await client.PostAsync($"{EndPointAPi}/Login",stringContent);
            if (!response.IsSuccessStatusCode)
                return null;
            var responseApi =await response.Content.ReadAsStreamAsync();
            var codeAuthorization = JsonSerializer.Deserialize<string>(responseApi,_jsonSerializerOptions);
    
            var token = await GetAccessTokenOfAuthenticationCode(codeAuthorization);
            var modelReturn = new UserToken { Token = token };
            return modelReturn;
        }

    public async Task<Models.User> GetUserOfToken(string token)
    {
        var client = _clientFactory.CreateClient(ClientAuth);
        var userJson = JsonSerializer.Serialize(token);
        var stringContent = new StringContent(userJson,Encoding.UTF8,"application/json");
        using var response = await client.PostAsync($"{EndPointAPi}/InfoUser",stringContent);
        if (!response.IsSuccessStatusCode)
            return null;
        var responseApi =await response.Content.ReadAsStreamAsync();
        var user = JsonSerializer.Deserialize<Models.User>(responseApi,_jsonSerializerOptions);
        
        return user;
    }
    private async Task<string> GetAccessTokenOfAuthenticationCode(string code)
    {
        var client = _clientFactory.CreateClient(ClientAuth);
        var codeAuth = JsonSerializer.Serialize(code);
        var stringContent = new StringContent(codeAuth,Encoding.UTF8,"application/json");
        using var response = await client.PostAsync($"{EndPointAPi}/CodeAuthentication",stringContent);
        if (!response.IsSuccessStatusCode)
            return null;
        var responseApi =await response.Content.ReadAsStreamAsync();
        var token = JsonSerializer.Deserialize<string>(responseApi,_jsonSerializerOptions);

        return token;
    }
}