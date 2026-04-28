namespace Day05V2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Male,
        Female
    }
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [EgyptianPhone(ErrorMessage = "Phone must be a valid Egyptian number (01xxxxxxxxx)")]
        public string PhoneNum { get; set; }

        public virtual IEnumerable<Order>? Orders { get; set; }
    }
}
