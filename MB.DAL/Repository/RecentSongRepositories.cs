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
    public class RecentSongRepositories
    {
        private MusicPlayerDBContext _context;
        public List<RecentSong> GetAll()
        {
            _context = new();
            return _context.RecentSongs.Include("Songs").ToList();
        }
        public void Add(RecentSong song)
        {
            _context = new();
            _context.RecentSongs.Add(song);
            _context.SaveChanges();
        }
    }
}
