using MB.DAL.Models;
using MP.BLL.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for PlaylistPage.xaml
    /// </summary>
    public partial class PlaylistPage : Page
    {
        private PlaylistService _playlistService = new();

        public PlaylistPage()
        {
            InitializeComponent();
        }

        private void AddPlaylist_Click(object sender, RoutedEventArgs e)
        {
            AddSongPopup.IsOpen = true;
            AddSongPopup.Placement = PlacementMode.Center;
        }
        private void FillData()
        {
            PlayListData.ItemsSource = null;
            PlayListData.ItemsSource = _playlistService.GetPlaylists();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int playlistId=0;
            if (sender is Border border && border.DataContext is Playlists playlist)
            {
                playlistId = playlist.PlayListId;
            }
            Playlists? a = _playlistService.GetPlaylistsByID(playlistId);
            PlayListSong playListSongPage = new PlayListSong();
            playListSongPage.CurrentPlaylist = a;
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(playListSongPage);
            
        }
    }
}
