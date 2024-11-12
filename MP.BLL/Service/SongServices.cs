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
    public class SongServices
    {
        private SongRepositories _repo = new();
        public List<Songs> GetAllSong()
        {
            return _repo.GetAll();
        }
        public Songs? GetByIdSong(int id)
        {
            return _repo.GetById(id);
        }
        public List<Songs> SearchSong(string searchTerm)
        {
            return _repo.Search(searchTerm);
        }

        public void AddSong(Songs song)
        {
            _repo.Add(song);
        }

        public void UpdateSong(Songs song)
        {
            _repo.Update(song);
        }

        public void DeleteSong(Songs song)
        {
            _repo.Delete(song);
        }
    }
}
