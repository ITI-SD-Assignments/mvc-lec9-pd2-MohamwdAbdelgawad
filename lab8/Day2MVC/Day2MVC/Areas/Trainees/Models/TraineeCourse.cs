using System.ComponentModel.DataAnnotations;

namespace Day2MVC.Areas.Trainees.Models
{

    public class TraineeCourse
    {
        // Composite Primary Key (configured in DbContext)
        public int TraineeID { get; set; }
        public int CourseID { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public float Grade { get; set; }

        // Navigation properties — nullable
        public Trainee? Trainee { get; set; }
        public Course? Course { get; set; }
    }
}
