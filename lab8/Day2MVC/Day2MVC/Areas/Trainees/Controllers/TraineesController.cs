using Day2MVC.Areas.Trainees.Models;
using System.Linq;
using Day2MVC.Areas.Trainees.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day2MVC.Areas.Trainees.Controllers
{
    [Area("Trainees")]
        public class TraineesController : Controller
        {
            private readonly ITraineeRepository _traineeRepo;
            private readonly ITrackRepository _trackRepo;

            public TraineesController(ITraineeRepository traineeRepo, ITrackRepository trackRepo)
            {
                _traineeRepo = traineeRepo;
                _trackRepo = trackRepo;
            }

            public IActionResult Index()
            {
                List<Trainee> trainees = _traineeRepo.GetAllWithDetails();
                return View(trainees);
            }

            public IActionResult Details(int id)
            {
                Trainee trainee = _traineeRepo.GetByIdWithCourses(id);
                if (trainee == null) return NotFound();
                return View(trainee);
            }

            public IActionResult Create()
            {
                FillTrackDropDown();
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Trainee trainee)
            {
                if (ModelState.IsValid)
                {
                    _traineeRepo.Add(trainee);
                    TempData["Success"] = "Trainee added successfully!";
                    return RedirectToAction("Index");
                }
                FillTrackDropDown(trainee.TrackID);
                return View(trainee);
            }

            public IActionResult Edit(int id)
            {
                Trainee trainee = _traineeRepo.GetById(id);
                if (trainee == null) return NotFound();
                FillTrackDropDown(trainee.TrackID);
                return View(trainee);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, Trainee trainee)
            {
                if (id != trainee.ID) return BadRequest();
                if (ModelState.IsValid)
                {
                    _traineeRepo.Update(trainee);
                    TempData["Success"] = "Trainee updated successfully!";
                    return RedirectToAction("Index");
                }
                FillTrackDropDown(trainee.TrackID);
                return View(trainee);
            }

            public IActionResult Delete(int id)
            {
                Trainee trainee = _traineeRepo.GetByIdWithCourses(id);
                if (trainee == null) return NotFound();
                return View(trainee);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                _traineeRepo.Delete(id);
                TempData["Success"] = "Trainee deleted successfully!";
                return RedirectToAction("Index");
            }

            // Helper to fill track dropdown
            private void FillTrackDropDown(int selectedId = 0)
            {
                List<Track> tracks = _trackRepo.GetAll();
                ViewBag.TrackID = new SelectList(tracks, "ID", "Name", selectedId);
            }
        }
    }

