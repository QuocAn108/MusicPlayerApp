using MB.DAL.Models;
using MP.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicPlayer.MediaControl
{
    public class MediaService
    {
        private MediaPlayer _mediaPlayer = new MediaPlayer();
        private int _currentIndex = -1;
        private SongServices _songServices = new();
        public bool IsPlaying { get; private set; } = false;
        public Songs CurrentSong { get; private set; }

        public MediaService()
        {
            _mediaPlayer.MediaEnded += MediaPlayer_MediaEnded; 
        }

        public void Pause()
        {
            if (IsPlaying)
            {
                _mediaPlayer.Pause();
                IsPlaying = false; 
            }
        }

        public void PlaySong(Songs song)
        {
            if (song != null)
            {
                if (CurrentSong != null && CurrentSong.FilePath == song.FilePath && _mediaPlayer.Position > TimeSpan.Zero)
                {
                    _mediaPlayer.Play();
                    IsPlaying = true;
                }
                else
                {
                    _mediaPlayer.Open(new Uri(song.FilePath));
                    _mediaPlayer.Play();
                    IsPlaying = true;
                }
                CurrentSong = song; 
            }
        }

        public void Next()
        {
            if (CurrentSong == null) return;

            _currentIndex++;
            if (_currentIndex >= _songServices.GetAllSong().Count)
                _currentIndex = 0;

            CurrentSong = _songServices.GetAllSong()[_currentIndex];
            if (CurrentSong != null)
            {
                PlaySong(CurrentSong); 
            }
        }

        public void Previous()
        {
            if (CurrentSong == null) return; 
            _currentIndex--;
            if (_currentIndex < 0)
                _currentIndex = _songServices.GetAllSong().Count - 1;

            CurrentSong = _songServices.GetAllSong()[_currentIndex];
            if (CurrentSong != null)
            {
                PlaySong(CurrentSong);
            }
        }

        public void SetVolume(double volume)
        {
            _mediaPlayer.Volume = volume / 100; 
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                Next();
            }
        }

    }
}
