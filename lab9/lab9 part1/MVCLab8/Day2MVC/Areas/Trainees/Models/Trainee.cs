using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab8.Areas.Trainees.Models
{

    public class Trainee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Mobile No.")]
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "Enter a valid Egyptian mobile number.")]
        public string MobileNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birthdate is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime Birthdate { get; set; }

        // Foreign Key
        [ForeignKey("Trk")]
        [Display(Name = "Track")]
        public int TrackID { get; set; }

        // Navigation property
        public Track? Trk { get; set; }

        // M:M with Course
        public IEnumerable<TraineeCourse>? TraineeCourses { get; set; }
    }
}
