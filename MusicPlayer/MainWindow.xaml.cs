using MB.DAL.Models;
using MP.BLL.Service;
using MusicPlayer.MediaControl;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaService _mediaService = new();
        public Songs CurrentSong { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ShowHomeContent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (_mediaService.IsPlaying)
            {
                _mediaService.Pause();
            }
            else
            {
                _mediaService.PlaySong(CurrentSong);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _mediaService.Next();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            _mediaService.Previous();
        }
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _mediaService.SetVolume(e.NewValue);
        }
        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new AddSongPage());
        }

        private void Playlists_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new PlaylistPage());
        }

        private void Library_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new LibraryPage());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ShowHomeContent();
        }
        private void ShowHomeContent()
        {
            MainFrame.Content = null;
            HomeContent.Visibility = Visibility.Visible;
        }
    }
}