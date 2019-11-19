using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Superheros.API.Extensions
{
    public static class MapperExtension
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
