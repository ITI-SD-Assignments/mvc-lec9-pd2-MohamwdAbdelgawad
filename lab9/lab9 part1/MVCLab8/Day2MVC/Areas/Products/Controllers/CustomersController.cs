using MVCLab8.Areas.Products.Repository;
using MVCLab8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MVCLab8.Areas.Products.Controllers

{
    [Area("Products")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repo;

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var c = _repo.GetById(id);
            if (c == null) return NotFound();
            var vm = new Product_Cust_ViewModel
            {
                CustomerID = c.ID,
                CustomerName = c.Name,
                Products = c.Products
            };
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MVCLab8.Areas.Products.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var c = _repo.GetById(id);
            if (c == null) return NotFound();
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MVCLab8.Areas.Products.Models.Customer customer)
        {
            if (id != customer.ID) return BadRequest();
            if (ModelState.IsValid)
            {
                _repo.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var c = _repo.GetById(id);
            if (c == null) return NotFound();
            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
