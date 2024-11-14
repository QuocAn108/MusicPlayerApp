using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Models
{
    public class RecentSong
    {
        [Key]
        public int RecentSongId { get; set; }
        public DateTime PlayAt { get; set; }
        public int SongId { get; set; }
        public Songs Songs { get; set; }


    }
}
