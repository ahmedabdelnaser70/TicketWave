using Microsoft.AspNetCore.Mvc;
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
    }
}
