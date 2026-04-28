using System.Collections.Generic;

namespace Day2MVC.Models
{
    public class Product_Cust_ViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public IEnumerable<Day2MVC.Areas.Products.Models.Product> Products { get; set; } = new List<Day2MVC.Areas.Products.Models.Product>();
    }
}
