using Day05V2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day05V2.Controllers
{
    public class OrderController : Controller
    {
        private CompanyDbContext _context;
        public OrderController(CompanyDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            ViewBag.custId = new SelectList(_context.Customers.ToList() , "ID" , "Name");
            return View(_context.Orders.Include(o => o.Customer).ToList());
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            int id = int.Parse(collection["custId"]);
            ViewBag.custId = new SelectList(_context.Customers.ToList(), "ID", "Name" , id);
            return View(_context.Orders.Include(o => o.Customer).ToList().Where(o => o.CustID == id));
        }

        public ActionResult Details(int id)
        {
            return View(_context.Orders.Include(o => o.Customer).FirstOrDefault(o =>o.ID == id));
        }

        public ActionResult Create()
        {
            ViewBag.customer = new SelectList(_context.Customers.ToList(), "ID", "Name");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            ViewBag.customer = new SelectList(_context.Customers.ToList(), "ID", "Name");
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
            
        }

        public ActionResult Edit(int id)
        {
            ViewBag.custId = new SelectList(_context.Customers.ToList(), "ID", "Name");
            return View(_context.Orders.Include(e => e.Customer).ToList().FirstOrDefault(e => e.ID == id));
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            Customer C = _context.Customers.Find(order.CustID);
            order.Customer = C;
            if (ModelState.IsValid)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Orders.Include(e => e.Customer).ToList().FirstOrDefault(e => e.ID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order order)
        {
            Order e = _context.Orders.Find(order.ID);
            try
            {
                _context.Orders.Remove(e);
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
