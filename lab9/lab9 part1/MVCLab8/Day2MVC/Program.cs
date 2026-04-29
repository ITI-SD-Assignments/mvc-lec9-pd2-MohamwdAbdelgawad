using MVCLab8.Areas.Trainees.Repository;
using MVCLab8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MVCLab8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews(
               conf =>
               conf.Filters.Add(new AuthorizeFilter())
               );
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Custom Service Injection
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            // Products area services
            builder.Services.AddScoped<MVCLab8.Areas.Products.Repository.IProductRepository, MVCLab8.Areas.Products.Repository.ProductRepository>();
            builder.Services.AddScoped<MVCLab8.Areas.Products.Repository.ICustomerRepository, MVCLab8.Areas.Products.Repository.CustomerRepository>();

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

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
