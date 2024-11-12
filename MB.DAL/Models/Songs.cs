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
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Artist { get; set; }

        [MaxLength(255)]
        public string Album { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FilePath { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }

        public uint? Year { get; set; }

        public byte[] AlbumArtData { get; set; }

        [MaxLength(50)]
        public string FileFormat { get; set; }

        public long FileSize { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? LastPlayed { get; set; }

        public int PlayCount { get; set; }
    }
}
