using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Superheros.API.Extensions;

namespace Superheros.API
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = _configuration["IdentityServer:Authority"];
                    options.RequireHttpsMetadata = true;
                    options.ApiName = _configuration["IdentityServer:ApiName"];

                });

            services.AddDatabaseService();

            services.AddMapperService();

            services.AddMvcService();

            services.AddSwaggerService();
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseHsts();
            }

            application.UseAuthentication();

            application.UseHttpsRedirection();
            application.UseMvc();

            application.UseSwaggerService();
        }
    }
}
