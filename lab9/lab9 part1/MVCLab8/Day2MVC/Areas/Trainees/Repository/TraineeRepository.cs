using MVCLab8.Areas.Trainees.Models;
using MVCLab8.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCLab8.Areas.Trainees.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly AppDbContext _context;

        public TraineeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trainee> GetAll()
        {
            return _context.Trainees.ToList();
        }

        public Trainee GetById(int id)
        {
            return _context.Trainees.Find(id);
        }

        public List<Trainee> GetAllWithDetails()
        {
            return _context.Trainees
                .Include(t => t.Trk)
                .Include(t => t.TraineeCourses)
                    .ThenInclude(tc => tc.Course)
                .ToList();
        }

        public Trainee GetByIdWithCourses(int id)
        {
            return _context.Trainees
                .Include(t => t.Trk)
                .Include(t => t.TraineeCourses)
                    .ThenInclude(tc => tc.Course)
                .FirstOrDefault(t => t.ID == id);
        }

        public void Add(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
        }

        public void Update(Trainee trainee)
        {
            _context.Trainees.Update(trainee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Trainee trainee = _context.Trainees.Find(id);
            if (trainee != null)
            {
                _context.Trainees.Remove(trainee);
                _context.SaveChanges();
            }
        }
    }
}
