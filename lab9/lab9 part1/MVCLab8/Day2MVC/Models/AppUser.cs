using Microsoft.AspNetCore.Identity;

namespace MVCLab8.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? nationality { get; set; }
        public string? EducationLevel { get; set; }

    }
}
