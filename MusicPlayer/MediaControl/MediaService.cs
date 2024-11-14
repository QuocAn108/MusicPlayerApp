using MB.DAL.Models;
using Microsoft.EntityFrameworkCore;
using MP.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace MusicPlayer.MediaControl
{
    public class MediaService
    {
        private MediaPlayer _mediaPlayer = new();
        private RecentSongService _rsService = new();
        private int _currentIndex = -1;
        public bool IsPlaying { get; private set; } = false;
        public Songs CurrentSong { get; set; }
        public List<Songs> Playlist { get; set; } = new();
        private DispatcherTimer _timer;
        public event Action<TimeSpan> PositionChanged;
        public MediaService()
        {
            _mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (sender, args) =>
            {
                PositionChanged?.Invoke(_mediaPlayer.Position);
            };
        }
        public void Pause()
        {
            if (IsPlaying)
            {
                _mediaPlayer.Pause();
                _timer.Stop();
                IsPlaying = false;
            }
        }
        public void PlaySong(Songs song)
        {
            if (song != null)
            {
                if (CurrentSong != null && CurrentSong.FilePath == song.FilePath && _mediaPlayer.Position > TimeSpan.Zero)
                    _mediaPlayer.Play();
                else
                {
                    _mediaPlayer.Open(new Uri(song.FilePath));
                    _mediaPlayer.Play();
                }
                _timer.Start();
                IsPlaying = true;
                CurrentSong = song;
                _currentIndex = Playlist.IndexOf(song);
                _rsService.AddRS(new RecentSong { SongId = song.SongId, PlayAt = DateTime.Now });

            }
        }

        public void Next()
        {
            if (Playlist == null || Playlist.Count == 0) return;

            _currentIndex = (_currentIndex + 1) % Playlist.Count;
            PlaySong(Playlist[_currentIndex]);
        }

        public void Previous()
        {
            if (Playlist == null || Playlist.Count == 0) return;

            _currentIndex = (_currentIndex - 1 + Playlist.Count) % Playlist.Count;
            PlaySong(Playlist[_currentIndex]);
        }

        public void SetVolume(double volume) => _mediaPlayer.Volume = volume / 100;

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (IsPlaying)
                Next();
        }

    }
}
