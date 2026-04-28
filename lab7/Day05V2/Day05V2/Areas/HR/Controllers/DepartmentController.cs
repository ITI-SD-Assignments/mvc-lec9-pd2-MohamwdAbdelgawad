using Day05V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day05V2.Areas.HR.Controllers
{
    [Area("HR")]
    public class DepartmentController : Controller
    {
        private readonly CompanyDbContext _context;

        public DepartmentController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(_context.Departments.ToList());
        }
        

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.Departments.ToList().FirstOrDefault(e => e.DeptID == id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            try
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeeController/Create


        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Departments.ToList().FirstOrDefault(e => e.DeptID == id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            
            try
            {
                _context.Departments.Update(dept);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Departments.ToList().FirstOrDefault(e => e.DeptID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department dept)
        {
            Department d = _context.Departments.Find(dept.DeptID);
            try
            {
                _context.Departments.Remove(d);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
