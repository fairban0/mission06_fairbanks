using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                .Include(m => m.Category)
                .OrderBy(m => m.Title)  // Sort alphabetically by Title
                .ToListAsync();

            return View(movies);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            // Get Categories for the dropdown
            ViewBag.Categories = _context.Categories.ToList();
            // Dropdown options for Rating
            ViewBag.RatingList = new SelectList(new List<string> { "NR", "G", "PG", "PG-13", "R" });

            // Dropdown options for Edited
            ViewBag.EditedList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Yes", Value = "true" },
                    new SelectListItem { Text = "No", Value = "false" }
                };
            // Dropdown options for CopiedToPlex
            ViewBag.CopiedToPlexList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Yes", Value = "true" },
                    new SelectListItem { Text = "No", Value = "false" }
                };

            // Dropdown options for LentTo (Yes/No displayed, True/False sent to DB)
            ViewBag.LentToList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Yes", Value = "true" },
                    new SelectListItem { Text = "No", Value = "false" }
                };


            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("ViewMovies");
            }

            // Reload Categories in case of validation error
            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }




    }
}
