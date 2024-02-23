using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Stevens.Models;
using System.Diagnostics;

namespace Mission6_Stevens.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext context) // Constructor
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
        public IActionResult AddMovie() // Display the form
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new Movie());
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response) // Process the form
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add the new movie to the database
                _context.SaveChanges(); // Save the changes
                return View("Confirmation", response);
            }
            else // Invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View("AddMovie", response);
            }

        }
        [HttpGet]
        public IActionResult ViewMovies() // Display the list of movies
        {
            //Linq Query
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);

        }

        [HttpGet]
        public IActionResult Edit(int id) // Display the edit form
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo) // Process the edit form
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id) // Display the deletion form
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie recordToDelete) // Process the deletion
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");

        }
    }
}
