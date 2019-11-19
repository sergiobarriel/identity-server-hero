using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4.Test;

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
