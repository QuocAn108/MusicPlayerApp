using MB.DAL.Models;
using MB.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.BLL.Service
{
    public class PlaylistService
    {
        private PlaylistRepositories _repo = new();
        public List<Playlists> GetPlaylists() => _repo.GetAll();
        public void AddPlaylist(Playlists a) => _repo.Add(a);
        public void UpdatePlaylist(Playlists a) => _repo.Update(a);

        public void DeletePlaylist(Playlists a) => _repo.Delete(a);
    }
}
