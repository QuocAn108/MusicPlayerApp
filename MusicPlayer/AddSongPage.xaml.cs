using MB.DAL.Models;
using Microsoft.Win32;
using MP.BLL.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddSongPage.xaml
    /// </summary>
    public partial class AddSongPage : Page
    {
        private readonly SongServices _songService =new();
        private readonly OpenFileDialog _openFileDialog;

        public AddSongPage()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*"
            };
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = _openFileDialog.FileName;

                // Tự động lấy thông tin từ file mp3 (nếu có)
                var file = TagLib.File.Create(_openFileDialog.FileName);
                TitleTextBox.Text = file.Tag.Title;
                ArtistTextBox.Text = file.Tag.FirstPerformer;
                AlbumTextBox.Text = file.Tag.Album;
                DurationTextBox.Text = file.Properties.Duration.ToString(@"mm\:ss");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var song = new Songs
                {
                    Title = TitleTextBox.Text,
                    Artist = ArtistTextBox.Text,
                    Album = AlbumTextBox.Text,
                    Duration = DurationTextBox.Text,
                    FilePath = FilePathTextBox.Text
                };

                _songService.AddSong(song);
                MessageBox.Show("Song added successfully!");

                // Clear form
                TitleTextBox.Clear();
                ArtistTextBox.Clear();
                AlbumTextBox.Clear();
                DurationTextBox.Clear();
                FilePathTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding song: {ex.Message}");
            }
        }
    }
}
