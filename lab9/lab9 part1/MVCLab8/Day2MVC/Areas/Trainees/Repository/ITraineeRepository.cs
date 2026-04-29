using MVCLab8.Areas.Trainees.Models;

namespace MVCLab8.Areas.Trainees.Repository
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
