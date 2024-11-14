using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Models
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Duration { get; set; }
        public string FilePath { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<RecentSong> RecentSongs { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
