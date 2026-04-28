using Day2MVC.Areas.Trainees.Models;
using System.Linq;
using Day2MVC.Areas.Trainees.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Areas.Trainees.Controllers
{
    [Area("Trainees")]
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepo;

        public TracksController(ITrackRepository trackRepo)
        {
            _trackRepo = trackRepo;
        }

        public IActionResult Index()
        {
            List<Track> tracks = _trackRepo.GetAllWithTrainees();
            return View(tracks);
        }

        public IActionResult Details(int id)
        {
            Track track = _trackRepo.GetAllWithTrainees()
                                    .FirstOrDefault(t => t.ID == id);
            if (track == null) return NotFound();
            return View(track);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        public IActionResult Edit(int id)
        {
            Track track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost]
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

        public IActionResult Delete(int id)
        {
            Track track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _trackRepo.Delete(id);
            TempData["Success"] = "Track deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}