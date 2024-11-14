using MB.DAL.Models;
using MB.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.BLL.Service
{
    public class RecentSongService
    {
        private RecentSongRepositories _repo = new();
        public List<RecentSong> GetAllRS()=> _repo.GetAll();
        public void AddRS(RecentSong song) => _repo.Add(song);
    }
}
