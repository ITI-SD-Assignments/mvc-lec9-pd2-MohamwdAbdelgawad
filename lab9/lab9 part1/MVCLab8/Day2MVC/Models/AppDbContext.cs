using MVCLab8.Areas.Trainees.Models;
using MVCLab8.Areas.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVCLab8.ViewModels;

namespace MVCLab8.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TraineeCourse> TraineeCourses { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure Identity entity types are configured
            base.OnModelCreating(modelBuilder);
            // Composite Primary Key for TraineeCourse (join table)
            modelBuilder.Entity<TraineeCourse>()
                .HasKey(tc => new { tc.TraineeID, tc.CourseID });

            // Trainee -> TraineeCourse (one side of M:M)
            modelBuilder.Entity<TraineeCourse>()
                .HasOne(tc => tc.Trainee)
                .WithMany(t => t.TraineeCourses)
                .HasForeignKey(tc => tc.TraineeID);

            // Course -> TraineeCourse (other side of M:M)
            modelBuilder.Entity<TraineeCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TraineeCourses)
                .HasForeignKey(tc => tc.CourseID);

            // Seed some data (optional)
            modelBuilder.Entity<Track>().HasData(
                new Track { ID = 1, Name = "PD", Description = "ASP.NET Core, EF Core, SQL Server , CRM" },
                new Track { ID = 2, Name = "IDA", Description = "ASP.NET Core, EF Core, SQL Server" }
            );
        }
       
    }
}



