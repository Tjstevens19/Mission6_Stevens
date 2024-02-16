using Microsoft.AspNetCore.Mvc;
//using Mission6_Stevens.Models;
using System.Diagnostics;

namespace Mission6_Stevens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }
    }
}
