using Day2MVC.Areas.Trainees.Models;

namespace Day2MVC.Areas.Trainees.Repository
{
   
        public interface ICourseRepository
        {
            List<Course> GetAll();
            Course GetById(int id);
            List<Course> GetAllWithTrainees();
        Course GetByIdWithTrainees(int id);
        void UpdateTrainees(int courseId, List<int> traineeIds);
            void Add(Course course);
            void Update(Course course);
            void Delete(int id);
        }
    }

