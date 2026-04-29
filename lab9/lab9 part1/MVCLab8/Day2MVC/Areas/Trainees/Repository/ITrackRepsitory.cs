using MVCLab8.Areas.Trainees.Models;

namespace MVCLab8.Areas.Trainees.Repository
{
    public interface ITrackRepository
    {
        List<Track> GetAll();
        Track GetById(int id);
        List<Track> GetAllWithTrainees();
        void Add(Track track);
        void Update(Track track);
        void Delete(int id);
    }
}
