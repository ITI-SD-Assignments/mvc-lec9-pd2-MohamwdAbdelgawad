namespace Day05V2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Order")]
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Total price is required")]
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal TotalPrice { get; set; }
        [ForeignKey("Customer")]
        [Required(ErrorMessage = "Customer must be selected")]
        public int CustID { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
