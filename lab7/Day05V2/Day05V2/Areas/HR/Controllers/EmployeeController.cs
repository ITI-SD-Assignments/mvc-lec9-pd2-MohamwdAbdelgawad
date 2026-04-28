using Day05V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day05V2.Areas.HR.Controllers
{
    [Area("HR")]  // Required so routing knows this controller belongs to the HR area
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            ViewBag.DeptId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Departments.ToList(), "DeptID", "Name");
            return View(_context.Employees.Include(e => e.Dept).ToList());
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            int id = int.Parse(collection["DeptId"]);
            ViewBag.DeptId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Departments.ToList(), "DeptID", "Name", id);
            return View(_context.Employees.Include(e => e.Dept).Where(d => d.DeptID == id).ToList());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.Employees.Include(e => e.Dept).ToList().FirstOrDefault(e => e.EmpID == id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Departments.ToList(), "DeptID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                _context.Employees.Add(emp);
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
            ViewBag.DeptId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Departments.ToList(), "DeptID", "Name");
            return View(_context.Employees.Include(e => e.Dept).ToList().FirstOrDefault(e => e.EmpID == id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
           Department dept = _context.Departments.Find(emp.DeptID);
            emp.Dept = dept;
            try
            {
                _context.Employees.Update(emp);
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
            return View(_context.Employees.Include(e => e.Dept).ToList().FirstOrDefault(e => e.EmpID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee emp)
        {
            Employee e = _context.Employees.Find(emp.EmpID);
            try
            {
                _context.Employees.Remove(e);
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
