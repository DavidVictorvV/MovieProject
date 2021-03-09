using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MoviesController : Controller
    {
        static List<Movie> movies = new List<Movie>()
        {
            new Movie() { ID = Guid.NewGuid(), MovieName = "Movie 1", Genre= "Action", MovieLength = 900, ReleaseDate = 2010 },
            new Movie() { ID = Guid.NewGuid(), MovieName = "Movie 3", Genre= "Comedy" ,MovieLength = 300, ReleaseDate = 2012},
            new Movie() { ID = Guid.NewGuid(), MovieName = "Movie 2", Genre= "Animated" ,MovieLength = 80, ReleaseDate = 2015},
            new Movie() { ID = Guid.NewGuid(), MovieName = "Movie 4", Genre= "Drama" ,MovieLength = 60, ReleaseDate = 2011},
            new Movie() { ID = Guid.NewGuid(), MovieName = "Movie 5", Genre = "Sci-Fi" ,MovieLength = 150, ReleaseDate = 2017},
             };

        private readonly MovieProjectContext _context;

        public MoviesController(MovieProjectContext context)
        {
            _context = context;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.FirstOrDefault(x => x.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.ID = Guid.NewGuid();

                movies.Add(movie);

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.FirstOrDefault(x => x.ID == id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,MovieName,Genre,MovieLength,ReleaseDate")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentMovie = movies.FirstOrDefault(x => x.ID == id);
                currentMovie.MovieName = movie.MovieName;
                currentMovie.Genre = movie.Genre;
                currentMovie.MovieLength = movie.MovieLength;
                currentMovie.ReleaseDate = movie.ReleaseDate;

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.FirstOrDefault(x => x.ID == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movie = movies.FirstOrDefault(x => x.ID == id);
            movies.Remove(movie);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
