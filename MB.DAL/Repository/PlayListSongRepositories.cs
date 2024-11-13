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
    public class PlayListSongRepositories
    {
        private MusicPlayerDBContext _context;
        public List<PlaylistSong> GetAll()
        {
            _context = new();
            return _context.PlaylistSongs.Include("Playlist").Include("Song").ToList();
        }
        public PlaylistSong? GetById(int songId, int PlayListId)
        {
            _context = new();
            return _context.PlaylistSongs.FirstOrDefault(x => x.SongId == songId && x.PlaylistId == PlayListId);
        }
        public List<PlaylistSong> GetByPlayListId(int PlayListId)
        {
            _context = new();
            return _context.PlaylistSongs.Where(x => x.PlaylistId == PlayListId).Include("Playlist").Include("Song").ToList();
        }

        public void Add(PlaylistSong song)
        {
            _context = new();
            _context.PlaylistSongs.Add(song);
            _context.SaveChanges();
        }
        public void Update(PlaylistSong song)
        {
            _context = new();
            _context.PlaylistSongs.Update(song);
            _context.SaveChanges();
        }
        public void Delete(PlaylistSong song)
        {
            _context = new();
            _context.PlaylistSongs.Remove(song);
            _context.SaveChanges();
        }
    }
}
