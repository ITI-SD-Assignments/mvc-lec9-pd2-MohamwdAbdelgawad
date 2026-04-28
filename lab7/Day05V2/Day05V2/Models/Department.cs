using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day05V2.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Employee>? Employees { get; set; }
    }
}
