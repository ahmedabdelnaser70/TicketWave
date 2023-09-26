using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketWave.Data;
using ticketWave.Data.Services;

namespace ticketWave.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
    }
}
