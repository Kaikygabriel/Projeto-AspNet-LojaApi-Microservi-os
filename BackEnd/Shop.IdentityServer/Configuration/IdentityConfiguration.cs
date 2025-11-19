using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace Shop.IdentityServer.Configuration;

public class IdentityConfiguration
{
    private const string Admin = "Admin";
    private const string Client = "Client";

    public static IEnumerable<IdentityResource> IdentityRosources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("Shop.Web","Shop Server"),
            new ApiScope("Read","Read data"),
            new ApiScope("Write","Write data"),
            new ApiScope("Delete","Delete data")
        };
    public static IEnumerable<Client> Clients=>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = {new Secret("teteste@!43ste".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,//precisa das credentials
                AllowedScopes = {"read","write","profile"}
            },
            new Client
            {
                ClientId = "Shop",
                ClientSecrets = {new Secret("teteste@!43ste".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"https://localhost:7085/signin-oidc"},
                PostLogoutRedirectUris = {"https://localhost:7085/sigout-callback-oidc"},
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    "Shop"
                }
            }
        };
}