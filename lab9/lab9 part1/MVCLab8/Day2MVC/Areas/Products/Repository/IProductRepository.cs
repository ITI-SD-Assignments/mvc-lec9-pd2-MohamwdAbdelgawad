using MVCLab8.Areas.Products.Models;
using System.Collections.Generic;

namespace MVCLab8.Areas.Products.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
