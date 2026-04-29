using System.ComponentModel.DataAnnotations;

namespace MVCLab8.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string nationality { get; set; }
        public string EducationLevel { get; set; }
    }
}
