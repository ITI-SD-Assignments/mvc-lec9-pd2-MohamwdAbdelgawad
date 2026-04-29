using MVCLab8.Areas.Trainees.Models;
using MVCLab8.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCLab8.Areas.Trainees.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AppDbContext _context;

        public TrackRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Track> GetAll()
        {
            return _context.Tracks.ToList();
        }

        public Track GetById(int id)
        {
            return _context.Tracks.Find(id);
        }

        public List<Track> GetAllWithTrainees()
        {
            return _context.Tracks.Include(t => t.Trainees).ToList();
        }

        public void Add(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
        }

        public void Update(Track track)
        {
            _context.Tracks.Update(track);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Track track = _context.Tracks.Find(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges();
            }
        }
    }
}
