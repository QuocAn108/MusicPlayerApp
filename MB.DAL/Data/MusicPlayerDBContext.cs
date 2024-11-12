using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Data
{
    public class MusicPlayerDBContext : dbcon
    {
        public DbSet<SongEntity> Songs { get; set; }
        public DbSet<PlaylistEntity> Playlists { get; set; }

        public MusicPlayerDbContext(DbContextOptions<MusicPlayerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongEntity>()
                .HasIndex(s => s.FilePath)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
