using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Configuration
{
    internal class Clients
    {
        /// <summary>
        /// http://docs.identityserver.io/en/latest/reference/client.html
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> Get(Dictionary<string, string> clientsUrl)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "api",
                    ClientName = "Api client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("Allr2goS@ftSecretKey".Sha256())}, // change me!
                    AllowedScopes = new List<string> {"awms.api.get", "awms.api.post", "awms.api.put", "awms.api.delete", "awms.api.full" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "Mvc Client Application",
                    ClientSecrets = new List<Secret> {new Secret("Allr2goS@ftSecretKey".Sha256())}, // change me!
                    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:44311/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> {"https://localhost:44311/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "awms.api.full"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                new Client
                {
                    ClientId = "admin",
                    ClientName = "Admin Client",
                    ClientSecrets = new List<Secret> {new Secret("Allr2goS@ftSecretKey".Sha256())}, // change me!
                    ClientUri = "https://localhost:44311",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44311/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44311/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "role",
                        "awms.api.full"
                    },
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                },
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string>{"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "awms.api",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"awms.api.get", "awms.api.post", "awms.api.put", "awms.api.delete", "awms.api.full"},
                    ApiSecrets = new List<Secret> {new Secret("Allr2goS@ftSecretKey".Sha256())}, // change me!
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("awms.api.get", "Read Access to API #1"),
                new ApiScope("awms.api.post", "Write Access to API #1"),
                new ApiScope("awms.api.put", "Update Access to API #1"),
                new ApiScope("awms.api.delete", "Delete Access to API #1"),
                new ApiScope
                {
                    Name = "awms.api.full",
                    Description = "Full Access to API #1",
                    UserClaims = new List<string>()
                    {
                        "Administrator"
                    }
                }
            };
        }
    }
}
