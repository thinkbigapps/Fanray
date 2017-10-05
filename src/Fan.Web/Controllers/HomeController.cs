using Fan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fan.Web.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> _logger;
        AppSettings _settings;
        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<AppSettings> options)
        {
            _logger = logger;
            _settings = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application description page. " + _settings.Version;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
