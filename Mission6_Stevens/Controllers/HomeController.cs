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
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new Movie());
        }
        [HttpPost]
        public IActionResult AddMovie(Movie response)
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
        public IActionResult ViewMovies()
        {
            //Linq Query
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);

        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var recordToEdit = _context.Movies
        //        .Single(x => x.MovieId == id);

        //    ViewBag.Categories = _context.Categories
        //        .OrderBy(x => x.CategoryName)
        //        .ToList();
        //    return View("DatingApplication", recordToEdit);
        //}
        //[HttpPost]
        //public IActionResult Edit(AddMovieModel response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Movies.Update(response);
        //        _context.SaveChanges();
        //        return View("Confirmation", response);
        //    }
        //    else
        //    {
        //        ViewBag.Categories = _context.Categories
        //            .OrderBy(x => x.CategoryName)
        //            .ToList();
        //        return View("DatingApplication", response);
        //    }
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var recordToDelete = _context.Movies
        //        .Single(x => x.MovieId == id);
        //    return View(recordToDelete);
        //}
        //[HttpPost]
        //public IActionResult Delete(AddMovieModel response)
        //{
        //    _context.Movies.Remove(response);
        //    _context.SaveChanges();
        //    return RedirectToAction("ViewMovies");

    }
}
