using Microsoft.Extensions.Caching.Memory;
using Shop.Auth.Serviços.Interfaces;

namespace Shop.Auth.Serviços;

public class AuthenticationTokenService : IAuthenticationTokenService
{
    private readonly IUserManager _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;
    private readonly ITokenService _tokenService;

    public AuthenticationTokenService(IMemoryCache memoryCache, ITokenService tokenService, IConfiguration configuration, IUserManager userManager)
    {
        _memoryCache = memoryCache;
        _tokenService = tokenService;
        _configuration = configuration;
        _userManager = userManager;
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


    public async Task<string> GenerateAccessToken(string authenticationCode)
    {
        if (!_memoryCache.TryGetValue(authenticationCode, out string? emailAddress))
            return null;
        var user = await _userManager.FindUserByEmail(emailAddress);
        if (user is null)
            return null;
        
        return _tokenService.GerenateAcessToken(_tokenService.GetClaimsOfUser(user),_configuration);
    }
    
}