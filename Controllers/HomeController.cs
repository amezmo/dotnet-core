
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

            return new JsonResult(new {
                Client = Request.HttpContext.Connection.RemoteIpAddress,
                IsHttps = Request.IsHttps,
                Environment = webHostEnvironment.EnvironmentName,
                Headers = Request.Headers.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value)
            }, options);
        }
    }
}