using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Superheros.WebClient
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = _configuration["Flows:Implicit:Scheme"];
                options.DefaultChallengeScheme = _configuration["Flows:Implicit:ChallengeScheme"];
            })
            .AddCookie(_configuration["Flows:Implicit:Scheme"])
            .AddOpenIdConnect(_configuration["Flows:Implicit:ChallengeScheme"], options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = _configuration["IdentityServer:Authority"];
                options.RequireHttpsMetadata = true;
                options.ClientId = _configuration["Flows:Implicit:ClientId"];
                options.SaveTokens = true;
            });

        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseAuthentication();

            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Home/Error");
                application.UseHsts();
            }

            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseCookiePolicy();

            application.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
