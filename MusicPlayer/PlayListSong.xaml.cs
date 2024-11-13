using MB.DAL.Models;
using MP.BLL.Service;
using MusicPlayer.MediaControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for PlayListSong.xaml
    /// </summary>
    public partial class PlayListSong : Page
    {
        private MediaService _mediaServic = new();
        private PlayListSongService _psService = new();
        public Playlists CurrentPlaylist {  get; set; }
        public PlayListSong()
        {
            InitializeComponent();
        }
        private void LoadPS()
        {
            var ps = _psService.GetByPlayListId(CurrentPlaylist.PlayListId);
            ListSongView.ItemsSource = ps;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPS();
        }
        //private void SongListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count > 0 && e.AddedItems[0] is Songs song)
        //    {
        //        _currentSong = song;
        //        var mainWindow = (MainWindow)Application.Current.MainWindow;
        //        mainWindow.MediaService.PlaySong(song);
        //        mainWindow.UpdateSongInfo(song.Title, song.Artist);
        //    }
        //}
    }
}
