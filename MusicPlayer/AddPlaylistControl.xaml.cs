using MB.DAL.Models;
using MP.BLL.Service;
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
    /// Interaction logic for AddPlaylistControl.xaml
    /// </summary>
    public partial class AddPlaylistControl : UserControl
    {
        private PlaylistService _service = new();
        public event EventHandler ClosePopupRequested;
        public AddPlaylistControl()
        {
            InitializeComponent();
        }
        private void CancelAddPlaylist_Click(object sender, RoutedEventArgs e)
        {
             MessageBoxResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ClosePopupRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var playlist = new Playlists
                {
                    Name = NewPlaylistNameTextBox.Text,
                };

                _service.AddPlaylist(playlist);
                MessageBox.Show("Playlist added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding song: {ex.Message}");
            }
        }
    }
}
