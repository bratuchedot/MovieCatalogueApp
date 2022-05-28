using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieCatalogueApp.Data;
using MovieCatalogueApp.Models;

namespace MovieCatalogueApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return _context.Movie != null ? 
                          View(await _context.Movie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/InsertNewPerson/5
        public ActionResult InsertNewPerson(int id)
        {
            MoviePerson model = new MoviePerson();
            model.MovieId = id;
            model.Movie = _context.Movie.Find(id);
            model.People = _context.Person.ToList();
            ViewBag.People = _context.Person.ToList();
            return View(model);
        }

        // POST: Movies/InsertNewPerson/5
        [HttpPost]
        public ActionResult InsertNewPerson(MoviePerson model)
        {
            var Person = _context.Person.FirstOrDefault(person => person.Id == model.PersonId);
            var Movie = _context.Movie.FirstOrDefault(movie => movie.Id == model.MovieId);
            Movie.CastAndCrew.Add(Person);
            _context.SaveChanges();
            return View("Index", _context.Movie.ToList());
        }

        // GET: Movies/InsertNewGenre/5
        public ActionResult InsertNewGenre(int id)
        {
            MovieGenre model = new MovieGenre();
            model.movieId = id;
            model.movie = _context.Movie.Find(id);
            model.genres = _context.Genre.ToList();
            ViewBag.Genres = _context.Genre.ToList();
            return View(model);
        }

        // POST: Movies/InsertNewGenre/5
        [HttpPost]
        public ActionResult InsertNewGenre(MovieGenre model)
        {
            var Genre = _context.Genre.FirstOrDefault(genre => genre.Id == model.genreId);
            var Movie = _context.Movie.FirstOrDefault(movie => movie.Id == model.movieId);
            Movie.Genres.Add(Genre);
            _context.SaveChanges();
            return View("Index", _context.Movie.ToList());
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
