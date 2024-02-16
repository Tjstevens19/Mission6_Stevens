using Microsoft.AspNetCore.Mvc;
using Mission6_Stevens.Models;
using System.Diagnostics;

namespace Mission6_Stevens.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieModelContext _context;
        public HomeController(AddMovieModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieModel response)
        {
            _context.Movies.Add(response); // Add the new movie to the database
            _context.SaveChanges(); // Save the changes
            return View("Confirmation", response);
        }
    }
}
