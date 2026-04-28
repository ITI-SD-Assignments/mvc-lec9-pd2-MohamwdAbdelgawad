using System.ComponentModel.DataAnnotations;

namespace Day2MVC.Areas.Trainees.Models
{

    public class Track
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Track name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [Display(Name = "Track Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        // Navigation property — nullable (1:M with Trainees)
        public IEnumerable<Trainee>? Trainees { get; set; }
    }
}
