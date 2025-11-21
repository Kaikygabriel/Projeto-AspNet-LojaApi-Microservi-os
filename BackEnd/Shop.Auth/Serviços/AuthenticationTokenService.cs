using Microsoft.Extensions.Caching.Memory;
using Shop.Auth.Serviços.Interfaces;

namespace Shop.Auth.Serviços;

public class AuthenticationTokenService : IAuthenticationTokenService
{
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;
    private readonly ITokenService _tokenService;

    public AuthenticationTokenService(IMemoryCache memoryCache, ITokenService tokenService, IConfiguration configuration)
    {
        _memoryCache = memoryCache;
        _tokenService = tokenService;
        _configuration = configuration;
    }

    public string GenerateAuthenticationToken(string email)
    {
        var guid = Guid.NewGuid().ToString("N");
        
            var options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddMinutes(2)
            };
            _memoryCache.Set(guid, email, options);
            return guid;
        
    }

    public string GenerateAccessToken(string authenticationCode)
    {
        throw new NotImplementedException();
    }
    
}