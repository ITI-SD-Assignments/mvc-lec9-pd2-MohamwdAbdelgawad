using System.Collections.Generic;

namespace MVCLab8.Models
{
    public class Product_Cust_ViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public IEnumerable<MVCLab8.Areas.Products.Models.Product> Products { get; set; } = new List<MVCLab8.Areas.Products.Models.Product>();
    }
}
