using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Superheros.API.Models;

namespace Superheros.API.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabaseService(this IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<HeroContext>((serviceProvider, options) => options.UseInMemoryDatabase("HeroDatabase").UseInternalServiceProvider(serviceProvider));
        }
    }
}
