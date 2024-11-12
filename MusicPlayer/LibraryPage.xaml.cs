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
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        private MediaService _mediaService;
        private SongServices _songServices = new();
        private Songs _currentSong;

        public LibraryPage()
        {
            InitializeComponent();
            _mediaService = new MediaService();
            LoadSongLibrary();
        }

        private void LoadSongLibrary()
        {
            var songs = _songServices.GetAllSong();
            SongListView.ItemsSource = songs;
        }

        private void SongListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is Songs song)
            {
                _currentSong = song;

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.CurrentSong = song;
            }
        }
    }
}
