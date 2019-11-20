using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Superheros.API.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info()
                {
                    Title = "Superheros API",
                    Version = "v1",
                    Contact = new Contact()
                    {
                        Name = "Sergio Barriel",
                        Url = "https://twitter.com/sergiobarriel"
                    },
                });
            });
        }

        public static void UseSwaggerService(this IApplicationBuilder application)
        {
            application.UseSwagger();

            application.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Superhero API");
            });
        }
    }
}
