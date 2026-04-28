using Day2MVC.Areas.Trainees.Models;
using System.Linq;
using Day2MVC.Areas.Trainees.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Areas.Trainees.Controllers
{
    [Area("Trainees")]
        public class CoursesController : Controller
        {
        private readonly ICourseRepository _courseRepo;
        private readonly ITraineeRepository _raineeRepository;

            public CoursesController(ICourseRepository courseRepo , ITraineeRepository traineeRepository)
            {
                _courseRepo = courseRepo;
                _raineeRepository = traineeRepository;
        }

            public IActionResult Index()
            {
                List<Course> courses = _courseRepo.GetAllWithTrainees();
                return View(courses);
            }

            public IActionResult Details(int id)
            {
                List<Course> courses = _courseRepo.GetAllWithTrainees();
                Course course = courses.FirstOrDefault(c => c.ID == id);
                if (course == null) return NotFound();
                return View(course);
            }

        // GET: Assign trainees to course
        public IActionResult Assign(int id)
        {
            var course = _courseRepo.GetByIdWithTrainees(id);
            if (course == null) return NotFound();
            var allTrainees = _courseRepo is null ? new List<Trainee>() : _raineeRepository.GetAll().ToList();
            // build select list with checkboxes in view
            ViewBag.AllTrainees = allTrainees;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(int id, List<int> traineeIds)
        {
            _courseRepo.UpdateTrainees(id, traineeIds ?? new List<int>());
            TempData["Success"] = "Course assignments updated.";
            return RedirectToAction("Details", new { id });
        }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Course course)
            {
                if (ModelState.IsValid)
                {
                    _courseRepo.Add(course);
                    TempData["Success"] = "Course created successfully!";
                    return RedirectToAction("Index");
                }
                return View(course);
            }

            public IActionResult Edit(int id)
            {
                Course course = _courseRepo.GetById(id);
                if (course == null) return NotFound();
                return View(course);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, Course course)
            {
                if (id != course.ID) return BadRequest();
                if (ModelState.IsValid)
                {
                    _courseRepo.Update(course);
                    TempData["Success"] = "Course updated successfully!";
                    return RedirectToAction("Index");
                }
                return View(course);
            }

            public IActionResult Delete(int id)
            {
                Course course = _courseRepo.GetById(id);
                if (course == null) return NotFound();
                return View(course);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                _courseRepo.Delete(id);
                TempData["Success"] = "Course deleted successfully!";
                return RedirectToAction("Index");
            }
        }
    }

