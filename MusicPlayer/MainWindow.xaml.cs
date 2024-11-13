using MB.DAL.Models;
using MP.BLL.Service;
using MusicPlayer.MediaControl;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        public MediaService MediaService { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ShowHomeContent();
            MediaService = new();
            MediaService.PositionChanged += UpdateTimeDisplay;
        }
        public void UpdateSongInfo(string title, string artist)
        {
            SongTitleText.Text = title;
            ArtistNameText.Text = artist;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (MediaService.IsPlaying)
            {
                MediaService.Pause();
                PlayButton.Content = "▶";
            }
            else
            {
                if (MediaService.CurrentSong != null)
                {
                    MediaService.PlaySong(MediaService.CurrentSong);
                }
                else if (MediaService.Playlist.Count > 0)
                {
                    MediaService.PlaySong(MediaService.Playlist[0]);
                }
                PlayButton.Content = "=";
            }
        }
 

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MediaService.Next();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            MediaService.Previous();
        }
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaService.SetVolume(e.NewValue);
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
        private void UpdateTimeDisplay(TimeSpan position)
        {
            if (MediaService.CurrentSong != null)
            {
                ElapsedTimeTextBlock.Text = position.ToString(@"mm\:ss");

                if (TimeSpan.TryParseExact(MediaService.CurrentSong.Duration, @"mm\:ss", null, out TimeSpan duration))
                    DurationTextBlock.Text = duration.ToString(@"mm\:ss");
            }
        }

    }
}