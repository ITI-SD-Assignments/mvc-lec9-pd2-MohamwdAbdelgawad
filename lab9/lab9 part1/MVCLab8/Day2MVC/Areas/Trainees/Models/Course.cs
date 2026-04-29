using System.ComponentModel.DataAnnotations;

namespace MVCLab8.Areas.Trainees.Models
{

    public class Course
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Topic is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Topic must be between 2 and 150 characters.")]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = "Grade is required.")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public float Grade { get; set; }

        // Navigation property
        public IEnumerable<TraineeCourse>? TraineeCourses { get; set; }
    }
}
