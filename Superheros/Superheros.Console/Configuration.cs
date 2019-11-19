using Microsoft.Extensions.Configuration;
using System.IO;

namespace Superheros.Console
{
    internal class Configuration
    {
        internal static IConfiguration Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
