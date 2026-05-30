using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Songliste
{
    public partial class AddSongWindow : Window
    {
        public AddSongWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Backdrop fade in
            var backdropAnim = new DoubleAnimation(0, 1, System.TimeSpan.FromMilliseconds(200));
            backdrop.BeginAnimation(OpacityProperty, backdropAnim);

            // Card slide up + fade in
            var slideAnim = new DoubleAnimation(40, 0, System.TimeSpan.FromMilliseconds(250))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            var fadeAnim = new DoubleAnimation(0, 1, System.TimeSpan.FromMilliseconds(220));
            cardSlide.BeginAnimation(TranslateTransform.YProperty, slideAnim);
            card.BeginAnimation(OpacityProperty, fadeAnim);

            txtTitle.Focus();
        }

        private void Close_Click(object sender, RoutedEventArgs e) => CloseWithAnimation(false);

        private void CloseWithAnimation(bool result)
        {
            var slideOut = new DoubleAnimation(0, 30, System.TimeSpan.FromMilliseconds(180))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            var fadeOut = new DoubleAnimation(1, 0, System.TimeSpan.FromMilliseconds(180));
            fadeOut.Completed += (s, e) =>
            {
                DialogResult = result;
            };
            cardSlide.BeginAnimation(TranslateTransform.YProperty, slideOut);
            card.BeginAnimation(OpacityProperty, fadeOut);
            backdrop.BeginAnimation(OpacityProperty, new DoubleAnimation(1, 0, System.TimeSpan.FromMilliseconds(180)));
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AddSong_Click(sender, null);
            else if (e.Key == Key.Escape)
                CloseWithAnimation(false);
        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            string title  = txtTitle.Text.Trim();
            string artist = txtArtist.Text.Trim();
            string year   = txtYear.Text.Trim();

            if (string.IsNullOrEmpty(title))  { ShowError("Bitte gib einen Titel ein."); return; }
            if (string.IsNullOrEmpty(artist)) { ShowError("Bitte gib einen Artist ein."); return; }
            if (string.IsNullOrEmpty(year))   { ShowError("Bitte gib ein Jahr ein."); return; }

            string path = SongService.GetSongsJsonPath();
            if (path == null) { ShowError("songs.json wurde nicht gefunden."); return; }

            var songs = SongService.LoadSongs();
            songs.Add(new Song { title = title, artist = artist, year = year });
            SongService.SaveSongs(songs);

            CloseWithAnimation(true);
        }

        private void ShowError(string message)
        {
            errorText.Text = message;
            errorBorder.Visibility = Visibility.Visible;

            var shake = new ThicknessAnimation(
                new Thickness(0), new Thickness(-6, 0, 6, 0),
                System.TimeSpan.FromMilliseconds(60))
            {
                AutoReverse = true, RepeatBehavior = new RepeatBehavior(3)
            };
            errorBorder.BeginAnimation(MarginProperty, shake);
        }
    }
}
