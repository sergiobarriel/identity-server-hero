using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Superheros.Console.Flows
{
    internal class ClientCredentialsFlow
    {
        private static IConfiguration _configuration;

        public static async Task Start()
        {
            _configuration = Configuration.Get();

            using var httpClient = new HttpClient();

            var discoveryDocument = await Common.GetDiscoveryDocument(httpClient);

            if (!discoveryDocument.IsError)
            {
                var isValidToken = await GetAndSetTokenAsync(httpClient, discoveryDocument);

                if (isValidToken)
                {
                    await ApiClient.AddHerosAsync(httpClient, _configuration);
                    await ApiClient.GetHerosAsync(httpClient, _configuration);
                }
            }

            System.Console.WriteLine("\r\n...");
            System.Console.ReadKey();
        }


        private static async Task<bool> GetAndSetTokenAsync(HttpClient httpClient, DiscoveryDocumentResponse discoveryDocument)
        {
            var tokenClient = new TokenClient(httpClient, new TokenClientOptions()
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _configuration["Flows:ClientCredentials:ClientId"],
                ClientSecret = _configuration["Flows:ClientCredentials:ClientSecret"],
            });

            var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync(_configuration["Flows:ClientCredentials:Resource"]);

            Display.Print($"Token: {tokenResponse.Json}");

            if (tokenResponse.IsError) return false;

            httpClient.SetBearerToken(tokenResponse.AccessToken);

            return true;

        }
    }
}
