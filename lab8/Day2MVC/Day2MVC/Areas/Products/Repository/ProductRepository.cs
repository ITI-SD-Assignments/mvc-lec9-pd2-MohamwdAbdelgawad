using Day2MVC.Areas.Products.Models;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Day2MVC.Areas.Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.Include(p => p.Customer).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(p => p.Customer).FirstOrDefault(p => p.ID == id)!;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Products.Find(id);
            if (p != null)
            {
                _context.Products.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
