using MVCLab8.Areas.Trainees.Models;
using System.Linq;
using MVCLab8.Areas.Trainees.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCLab8.Areas.Trainees.Controllers
{
    [Area("Trainees")]
    [Route("tracks")]
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepo;

        public TracksController(ITrackRepository trackRepo)
        {
            _trackRepo = trackRepo;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            List<Track> tracks = _trackRepo.GetAllWithTrainees();
            return View(tracks);
        }

        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            Track track = _trackRepo.GetAllWithTrainees()
                                    .FirstOrDefault(t => t.ID == id);
            if (track == null) return NotFound();
            return View(track);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Add(track);
                TempData["Success"] = "Track created successfully!";
                return RedirectToAction("Index");
            }
            return View(track);
        }

        [Route("edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            Track track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Track track)
        {
            if (id != track.ID) return BadRequest();
            if (ModelState.IsValid)
            {
                _trackRepo.Update(track);
                TempData["Success"] = "Track updated successfully!";
                return RedirectToAction("Index");
            }
            return View(track);
        }

        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Track track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _trackRepo.Delete(id);
            TempData["Success"] = "Track deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}