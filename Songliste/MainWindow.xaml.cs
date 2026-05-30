using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Songliste
{
    public class SongRow : System.ComponentModel.INotifyPropertyChanged
    {
        private int _index;
        public Song Song { get; set; }
        public int Index
        {
            get => _index;
            set { _index = value; PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Index))); }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }

    public partial class MainWindow : Window
    {
        private List<Song> _allSongs = new List<Song>();
        private ObservableCollection<SongRow> _displayedRows = new ObservableCollection<SongRow>();

        public MainWindow()
        {
            InitializeComponent();
            songsList.ItemsSource = _displayedRows;
            Loaded += (s, e) => LoadSongs();
        }

        public void LoadSongs()
        {
            _allSongs = SongService.LoadSongs();
            ApplyFilter(searchBox.Text);
            UpdatePath();
        }

        private void ApplyFilter(string query)
        {
            _displayedRows.Clear();

            var filtered = string.IsNullOrWhiteSpace(query)
                ? _allSongs
                : _allSongs.Where(s =>
                    (s.title  ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (s.artist ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (s.year   ?? "").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

            for (int i = 0; i < filtered.Count; i++)
                _displayedRows.Add(new SongRow { Song = filtered[i], Index = i + 1 });

            songCountBadge.Text = $"{_allSongs.Count} Songs";
            emptyState.Visibility = _displayedRows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdatePath()
        {
            string path = SongService.GetSongsJsonPath();
            pathRun.Text = path ?? "Nicht gefunden";
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchPlaceholder.Visibility =
                string.IsNullOrEmpty(searchBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            ApplyFilter(searchBox.Text);
        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddSongWindow { Owner = this };
            if (dlg.ShowDialog() == true)
                LoadSongs();
        }

        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag is Song song)
                AnimateAndRemove(sender as FrameworkElement, song);
        }

        private void AnimateAndRemove(FrameworkElement trigger, Song song)
        {
            var rowObject = _displayedRows.FirstOrDefault(r => r.Song == song);
            if (rowObject == null) return;

            var container = songsList.ItemContainerGenerator.ContainerFromItem(rowObject) as FrameworkElement;
            var target = container ?? trigger;

            var fade = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(180));
            var slide = new ThicknessAnimation(
                new Thickness(0), new Thickness(40, 0, -40, 0),
                TimeSpan.FromMilliseconds(180))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };

            slide.Completed += (s2, e2) =>
            {
                _allSongs.Remove(song);
                SongService.SaveSongs(_allSongs);
                _displayedRows.Remove(rowObject);
                for (int i = 0; i < _displayedRows.Count; i++)
                    _displayedRows[i].Index = i + 1;
                songCountBadge.Text = $"{_allSongs.Count} Songs";
                emptyState.Visibility = _displayedRows.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            };

            target.BeginAnimation(OpacityProperty, fade);
            target.BeginAnimation(MarginProperty, slide);
        }

    }
}
