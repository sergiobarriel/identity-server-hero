using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Superheros.WebClient.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        private readonly IConfiguration _configuration;

        public PrivateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index() => View();

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(_configuration["Flows:Implicit:Scheme"]);
            await HttpContext.SignOutAsync(_configuration["Flows:Implicit:ChallengeScheme"]);
        }
    }
}