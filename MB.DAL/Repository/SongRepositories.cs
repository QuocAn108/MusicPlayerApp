using MB.DAL.Data;
using MB.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Repository
{
    public class SongRepositories
    {
        private MusicPlayerDBContext _context;
        public List<Songs> GetAll()
        {
            _context = new();
            return _context.Songs.ToList();
        }
        public Songs? GetById(int id)
        {
            _context = new();
            return _context.Songs.FirstOrDefault(x => x.SongId == id);
        }
        public List<Songs> Search(string searchTerm)
        {
            return _context.Songs
                .Where(s => s.Title.Contains(searchTerm) ||
                           s.Artist.Contains(searchTerm) ||
                           s.Album.Contains(searchTerm))
                .ToList();
        }

        public void Add(Songs song)
        {
            _context = new();
            song.DateAdded = DateTime.Now;
            _context.Songs.Add(song);
            _context.SaveChanges();
        }

        public void Update(Songs song)
        {
            _context = new();
            _context.Songs.Update(song);
            _context.SaveChanges();
        }

        public void Delete(Songs song)
        {
            _context = new();
            _context.Remove(song);
            _context.SaveChanges();
        }
    }
}
