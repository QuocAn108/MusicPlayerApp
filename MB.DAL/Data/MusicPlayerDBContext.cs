using MB.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MB.DAL.Data
{
    public class MusicPlayerDBContext : DbContext
    {
        public MusicPlayerDBContext()
        {

        }
        public MusicPlayerDBContext(DbContextOptions<MusicPlayerDBContext> options) : base(options)
        {

        }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<RecentSong> RecentSongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = GetConnectionString();
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string is not initialized.");
                }
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .Build();

            var strConn = config.GetConnectionString("DefaultConnectionStringDB");

            if (string.IsNullOrEmpty(strConn))
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);
            modelBuilder.Entity<RecentSong>()
                 .HasOne(rs => rs.Songs)
                 .WithMany(s => s.RecentSongs)
                 .HasForeignKey(rs => rs.SongId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
