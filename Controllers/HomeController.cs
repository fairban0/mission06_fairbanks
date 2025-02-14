using Microsoft.AspNetCore.Mvc;
using mission06_fairbanks.Models;

namespace mission06_fairbanks.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                ViewData["SuccessMessage"] = "Movie added successfully!";

                // Return a new, empty model to clear the form
                return View(new Movie());
            }

            return View(movie);
        }

    }
}
