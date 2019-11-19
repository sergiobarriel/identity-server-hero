using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;

namespace Superheros.Console.Flows
{
    internal class Common
    {
        internal static async Task<DiscoveryDocumentResponse> GetDiscoveryDocument(HttpClient httpClient)
        {
            var configuration = Configuration.Get();

            Display.Print($"Getting discovery document from {configuration["IdentityServer:Authority"]}");

            return await httpClient.GetDiscoveryDocumentAsync(configuration["IdentityServer:Authority"]);
        }
    }
}
