using Day2MVC.Areas.Trainees.Repository;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Custom Service Injection
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            // Products area services
            builder.Services.AddScoped<Day2MVC.Areas.Products.Repository.IProductRepository, Day2MVC.Areas.Products.Repository.ProductRepository>();
            builder.Services.AddScoped<Day2MVC.Areas.Products.Repository.ICustomerRepository, Day2MVC.Areas.Products.Repository.CustomerRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
