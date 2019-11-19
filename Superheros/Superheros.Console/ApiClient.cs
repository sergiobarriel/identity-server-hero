using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Superheros.Console
{
    internal class ApiClient
    {
        private static IEnumerable<object> GetHeros()
        {
            return new List<object>()
            {
                new { Name = "Spiderman", RealName = "Peter Parker" },
                new { Name = "Iron Man", RealName = "Tony Stark" },
                new { Name = "Captain America", RealName = "Steven Rogers" },
            };
        }

        internal static async Task AddHerosAsync(HttpClient httpClient, IConfiguration configuration)
        {
            Display.Print($"Adding new records on API...");

            foreach (var hero in GetHeros())
            {
                var content = new StringContent(JsonConvert.SerializeObject(hero), Encoding.UTF8, "application/json");

                await httpClient.PostAsync($"{configuration["HeroApi:Endpoint"]}/hero", content, new JsonMediaTypeFormatter());
            }
        }

        internal static async Task GetHerosAsync(HttpClient httpClient, IConfiguration configuration)
        {
            Display.Print("Getting records from API...");

            var response = await httpClient.GetAsync($"{configuration["HeroApi:Endpoint"]}/hero");

            Display.Print($"{JArray.Parse(await response.Content.ReadAsStringAsync())}");
        }

    }
}
