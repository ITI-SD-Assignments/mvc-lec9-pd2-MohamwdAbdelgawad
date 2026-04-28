using Day05V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day05V2.Controllers
{
   
        public class CustomerController : Controller
        {
            private CompanyDbContext _context;
            public CustomerController(CompanyDbContext context)
            {
                _context = context;
            }
            // GET: CustomerController
            public ActionResult Index()
            {
                return View(_context.Customers.ToList());
            }

            // GET: CustomerController/Details/5
            public ActionResult Details(int id)
            {
                return View(_context.Customers.FirstOrDefault(c => c.ID == id));
            }

            // GET: CustomerController/Create
            public ActionResult Create()
            {
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)));

            return View();
            }

            // POST: CustomerController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Customer cust)
            {
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)));
            if (ModelState.IsValid)
                {
                    _context.Customers.Add(cust);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cust);

            }

            // GET: CustomerController/Edit/5
            public ActionResult Edit(int id)
            {
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)));
            return View(_context.Customers.FirstOrDefault(c => c.ID == id));
            }

            // POST: CustomerController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Customer cust)
            {
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)));
            if (ModelState.IsValid) { 
              _context.Update(cust);
              _context.SaveChanges();
              return RedirectToAction("Index"); 
            }
            return View(cust);
        }

            public ActionResult Delete(int id)
            {
                return View(_context.Customers.FirstOrDefault(c => c.ID == id));
            }

            // POST: CustomerController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(Customer cust)
            {
            Customer c = _context.Customers.Find(cust.ID);
            try
            {
                _context.Customers.Remove(c);
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



