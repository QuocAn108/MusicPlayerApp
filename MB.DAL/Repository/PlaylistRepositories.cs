using MB.DAL.Data;
using MB.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Repository
{
    public class PlaylistRepositories
    {
        private MusicPlayerDBContext _context;
        public List<Playlists> GetAll()
        {
            _context = new();
            return _context.Playlists.ToList();
        }
        public Playlists? GetById(int id)
        {
            _context = new();
            return _context.Playlists.FirstOrDefault(x => x.PlayListId == id);
        }
        public void Add(Playlists playlist)
        {
            _context = new();
            playlist.CreatedDate = DateTime.Now;
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
        }
        public void Update(Playlists playlist)
        {
            _context = new();
            _context.Playlists.Update(playlist);
            _context.SaveChanges();
        }
        public void Delete(Playlists playlist)
        {
            _context = new();
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
        }

    }
}
