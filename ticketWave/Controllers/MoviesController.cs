using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ticketWave.Data.Services;
using ticketWave.Models;

namespace ticketWave.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        //{
        //    if (!ModelState.IsValid) return View(cinema);
        //    await _service.AddAsync(cinema);
        //    return RedirectToAction("Index");
        //}


        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var moviesDetails = await _service.GetMovieByIdAsync(id);
            if (moviesDetails == null) return View("NotFound");
            return View(moviesDetails);
        }
    }
}
