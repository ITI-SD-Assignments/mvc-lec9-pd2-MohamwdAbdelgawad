using Day2MVC.Areas.Products.Models;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Day2MVC.Areas.Products.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.Include(c => c.Products).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Include(c => c.Products).FirstOrDefault(c => c.ID == id)!;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _context.Customers.Find(id);
            if (c != null)
            {
                _context.Customers.Remove(c);
                _context.SaveChanges();
            }
        }
    }
}
