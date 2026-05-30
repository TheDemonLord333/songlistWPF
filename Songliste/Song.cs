using System.ComponentModel;

namespace Songliste
{
    public class Song : INotifyPropertyChanged
    {
        private string _title;
        private string _artist;
        private string _year;

        public string title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(title)); }
        }

        public string artist
        {
            get => _artist;
            set { _artist = value; OnPropertyChanged(nameof(artist)); }
        }

        public string year
        {
            get => _year;
            set { _year = value; OnPropertyChanged(nameof(year)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
