using Day2MVC.Areas.Products.Models;
using System.Collections.Generic;

namespace Day2MVC.Areas.Products.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
