using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mission6_Stevens.Models
{
    public class AddMovieModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Director { get; set; }

        [BindProperty]
        public string Genre { get; set; }

        [BindProperty]
        public int ReleaseYear { get; set; }

        [BindProperty]
        public string Rating { get; set; }

        [BindProperty]
        public bool Edited { get; set; }

        [BindProperty]
        public string LentTo { get; set; }

        [BindProperty]
        public string Notes { get; set; }

        public void OnGet()
        {
            // This method is called when the page is initially requested.
        }

        public IActionResult OnPost()
        {
            // This method is called when the form is submitted.
            // Handle the form submission logic here (e.g., save to a database).

            // Example: Save the movie data to a database
            // MovieDatabase.AddMovie(new Movie { Title = Title, Director = Director, ... });

            // Redirect to a confirmation page or the list of movies
            return RedirectToPage("/Movies/Index");
        }
    }
}
