using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Models
{
    public class Playlists
    {
        [Key]
        public int PlayListId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
