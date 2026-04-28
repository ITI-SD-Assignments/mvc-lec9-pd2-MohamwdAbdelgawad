using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Day2MVC.Areas.Products.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNum { get; set; } = string.Empty;

        public IEnumerable<Product>? Products { get; set; }
    }
}
