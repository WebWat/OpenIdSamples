using IdentityServer.Constants;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public class OpenIdConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new RoleIdentityResource()
            };


        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource> {
                new ApiResource(nameof(ApiConstants.WeatherForecastsAPI)){
                    Scopes = new List<string>()
                    {
                        ApiConstants.WeatherForecastsAPI
                    }
                }
            };


        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope(ApiConstants.WeatherForecastsAPI)
                {
                    Description = "Only get weather forecasts",
                    DisplayName = "Weather Forecasts API",
                    Emphasize = true
                }
            };


        public static IEnumerable<Client> GetClients() =>
            new List<Client> {
                new Client {
                    ClientName = "Blazor",
                    ClientId = "client_blazor",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    AllowedCorsOrigins = { UrlConstants.BlazorClient },

                    RedirectUris = { UrlConstants.BlazorClient + "/authentication/login-callback"  },
                    PostLogoutRedirectUris = { UrlConstants.BlazorClient + "/" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        ApiConstants.WeatherForecastsAPI
                    },

                    RequireConsent = true
                },

                new Client {
                    ClientName = "Razor Pages",
                    ClientId = "client_razor_pages",
                    ClientSecrets = { new Secret("client_razor_pages_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    AllowedCorsOrigins = { UrlConstants.RazorPagesClient },

                    RedirectUris = { UrlConstants.RazorPagesClient + "/signin-oidc"  },
                    PostLogoutRedirectUris = { UrlConstants.RazorPagesClient + "/signout-callback-oidc" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },

                    RequireConsent = false
                }
            };
    }
}
