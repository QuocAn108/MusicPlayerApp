using MB.DAL.Models;
using MB.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.BLL.Service
{
    public class PlayListSongService
    {
        private PlayListSongRepositories _repo = new();
        public List<PlaylistSong> GetAllPS() => _repo.GetAll();
        public PlaylistSong? GetByIdPS(int songId, int playListId) => _repo.GetById(songId, playListId);
        public List<PlaylistSong> GetByPlayListId(int PlayListId)=> _repo.GetByPlayListId(PlayListId);

        public void AddPS(PlaylistSong pls) => _repo.Add(pls);
        public void UpdatePS(PlaylistSong pls) => _repo.Update(pls);
        public void DeletePS(PlaylistSong pls) => _repo.Delete(pls);
    }
}
