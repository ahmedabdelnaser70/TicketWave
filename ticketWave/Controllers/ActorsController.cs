using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ticketWave.Data;
using ticketWave.Data.Services;
using ticketWave.Data.Static;
using ticketWave.Models;

namespace ticketWave.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);
            await _service.AddAsync(actor);
            return RedirectToAction("Index");
        }


        // Get: Actors/details/1 
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();
            var actorDetails = await _service.GetByIdAsync(id.Value);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }


        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if(actordetails == null) return View("NotFound");
            return View(actordetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if(!ModelState.IsValid && actor is null)
                return View(actor);

            if (id == actor.Id)
            {
                await _service.UpdateAsync(id, actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null) return View("NotFound");
            return View(actordetails);
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null)return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
