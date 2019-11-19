using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Superheros.IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Configuration.GetAllApiResources())
                .AddInMemoryClients(Configuration.GetClients())
                .AddTestUsers(Configuration.GetUsers().ToList()) // Specific for resource owner password flow
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources()); // Specific for implicit flow
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment()) application.UseDeveloperExceptionPage();

            application.UseIdentityServer();

            application.UseStaticFiles();

            application.UseMvcWithDefaultRoute();
        }
    }
}
