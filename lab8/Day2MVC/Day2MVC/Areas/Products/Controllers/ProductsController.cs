using Day2MVC.Areas.Products.Models;
using Day2MVC.Areas.Products.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Day2MVC.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly ICustomerRepository _custRepo;

        public ProductsController(IProductRepository repo, ICustomerRepository custRepo)
        {
            _repo = repo;
            _custRepo = custRepo;
        }

        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            return View(p);
        }

        public IActionResult Create()
        {
            FillCustomersDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction(nameof(Index));
            }
            FillCustomersDropDown(product.CustID);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            FillCustomersDropDown(p.CustID);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ID) return BadRequest();
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction(nameof(Index));
            }
            FillCustomersDropDown(product.CustID);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private void FillCustomersDropDown(int selectedId = 0)
        {
            var customers = _custRepo.GetAll();
            ViewBag.Customers = new SelectList(customers, "ID", "Name", selectedId);
        }
    }
}
