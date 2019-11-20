using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using IdentityServer4;

namespace Superheros.IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("superhero-api", "Superhero API"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                // Client credentials flow
                new Client()
                {
                    ClientId = "console-client-one",
                    ClientName = "Console client with client credentials flow",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("6DZh8pzKWp9QMlMh3h0uxbJDmwaDCF".Sha256(), null),
                    },
                    AllowedScopes = { "superhero-api" }
                },
                
                // Resource owner password flow
                new Client()
                {
                    ClientId = "console-client-two",
                    ClientName = "Console client with resource owner credentials flow",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("Y6b2jnjCfj8Z7w6hE371FE8g3hYeJL".Sha256(), null),
                    },
                    AllowedScopes = { "superhero-api" }
                },

                // Implicit flow
                new Client()
                {
                    ClientId = "web-client-one",
                    ClientName = "Web client with implicit flow",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    RedirectUris = { "https://localhost:5005/signin-oidc" },
                    PostLogoutRedirectUris = {"https://localhost:5005/signout-callback-oidc"}
                },

                // Implicit flow for Swagger
                new Client()
                {
                    ClientId = "web-client-swagger",
                    ClientName = "Web client for Swagger service",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "superhero-api" },
                    RedirectUris = { "https://localhost:5003/oauth2.redirect.html" },
                    PostLogoutRedirectUris = {"https://localhost:5003/swagger"},
                    AllowAccessTokensViaBrowser = true,
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
           {
               new TestUser()
               {
                   SubjectId = "1",
                   Username = "username",
                   Password = "password"
               },
               new TestUser()
               {
                   SubjectId = "2",
                   Username = "username-two",
                   Password = "password-two"
               }
           };
        }
    }
}
