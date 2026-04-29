using MVCLab8.Areas.Trainees.Models;
using MVCLab8.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCLab8.Areas.Trainees.Repository
{
   
        public class CourseRepository : ICourseRepository
        {
            private readonly AppDbContext _context;

            public CourseRepository(AppDbContext context)
            {
                _context = context;
            }

            public List<Course> GetAll()
            {
                return _context.Courses.ToList();
            }

            public Course GetById(int id)
            {
                return _context.Courses.Find(id);
            }

            public List<Course> GetAllWithTrainees()
            {
                return _context.Courses
                    .Include(c => c.TraineeCourses)
                        .ThenInclude(tc => tc.Trainee)
                    .ToList();
            }

        public Course GetByIdWithTrainees(int id)
        {
            return _context.Courses
                .Include(c => c.TraineeCourses)
                    .ThenInclude(tc => tc.Trainee)
                .FirstOrDefault(c => c.ID == id);
        }

        public void UpdateTrainees(int courseId, List<int> traineeIds)
        {
            var course = _context.Courses
                .Include(c => c.TraineeCourses)
                .FirstOrDefault(c => c.ID == courseId);
            if (course == null) return;

            var existing = course.TraineeCourses.ToList();
            foreach (var e in existing)
            {
                _context.TraineeCourses.Remove(e);
            }

            foreach (var tid in traineeIds)
            {
                _context.TraineeCourses.Add(new TraineeCourse { CourseID = courseId, TraineeID = tid });
            }
            _context.SaveChanges();
        }

            public void Add(Course course)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }

            public void Update(Course course)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                Course course = _context.Courses.Find(id);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                }
            }
        }
    }
