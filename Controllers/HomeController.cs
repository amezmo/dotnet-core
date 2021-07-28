
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

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
            return new JsonResult(new {
                Environment = webHostEnvironment.EnvironmentName
            });
        }
    }
}