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
        public MainWindow()
        {
            InitializeComponent();
            ShowHomeContent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSong_Click (object sender, RoutedEventArgs e)
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