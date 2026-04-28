using Day2MVC.Areas.Trainees.Models;
using Day2MVC.Areas.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2MVC.Models
{
    public class AppDbContext : DbContext
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



