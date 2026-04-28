using Day2MVC.Areas.Trainees.Models;

namespace Day2MVC.Areas.Trainees.Repository
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAll();
        Trainee GetById(int id);
        List<Trainee> GetAllWithDetails();
        Trainee GetByIdWithCourses(int id);
        void Add(Trainee trainee);
        void Update(Trainee trainee);
        void Delete(int id);
    }
}
