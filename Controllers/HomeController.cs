using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission07_fairbanks.Models;
using System.Linq;
using System.Threading.Tasks;

namespace mission07_fairbanks.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

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


        public IActionResult GetToKnowJoel()
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

        public async Task<IActionResult> ViewMovies()
        {
            var movies = await _context.Movies
                .Include(m => m.Category) // Include Category so we can access CategoryName
                .ToListAsync();

            return View(movies);
        }

    }
}
