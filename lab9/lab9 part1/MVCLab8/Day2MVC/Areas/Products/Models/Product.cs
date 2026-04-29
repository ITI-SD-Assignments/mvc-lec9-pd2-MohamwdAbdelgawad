using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab8.Areas.Products.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Image { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public Customer? Customer { get; set; }
    }
}
