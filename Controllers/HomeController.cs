
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Text.Json;

namespace dotnet_core.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [Route("")]
        [Route("/Index")]
        public IActionResult Index(int? id)
        {
            var options = new JsonSerializerOptions() {
                WriteIndented = true
            };

            // https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-5.0#forwarded-headers
            return new JsonResult(new {
                // X-Forwarded-For
                Client = HttpContext.Connection.RemoteIpAddress,
                // Host X-Forwarded-Host
                Host = HttpContext.Request.Host,
                // X-Forwarded-Proto
                XForwardedForScheme = HttpContext.Request.Scheme,
                IsHttps = Request.IsHttps,
                Environment = webHostEnvironment.EnvironmentName,
                Headers = Request.Headers.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value)
            }, options);
        }
    }
}