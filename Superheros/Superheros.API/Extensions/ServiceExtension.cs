using Microsoft.Extensions.DependencyInjection;
using Superheros.API.Abstractions;
using Superheros.API.Services;

namespace Superheros.API.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IHeroService, HeroService>();
        }
    }
}
