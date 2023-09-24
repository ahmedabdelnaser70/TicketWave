﻿using Microsoft.AspNetCore.Mvc;
using ticketWave.Data;
using ticketWave.Data.Services;
using ticketWave.Models;

namespace ticketWave.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // Get Actor details by id
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var result = await _service.GetByIdAsync(id.Value);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        // Add new Acotr
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction("Index");
        }

        //Get: Actors/Create
        public async Task<IActionResult> Edit(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);

            if(actordetails == null)
                return View("NotFound");

            return View(actordetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if(!ModelState.IsValid && actor is null)
                return View(actor);

            await _service.UpdateAsync(id, actor);
            return RedirectToAction("Index");
        }

        //Get: Actors/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);

            if (actordetails == null)
                return View("NotFound");

            return View(actordetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);

            if (actordetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
