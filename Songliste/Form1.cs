using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Songliste
{
    public partial class Form1 : Form
    {
        private List<AddSong.Songs> songs = new List<AddSong.Songs>();

        public Form1()
        {
            InitializeComponent();
        }

        private string GetSongsJsonPath()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);

            while (dir != null)
            {
                string possiblePath = Path.Combine(dir.FullName, "songs.json");
                if (File.Exists(possiblePath))
                    return possiblePath;
                dir = dir.Parent;
            }

            return Path.Combine(Application.StartupPath, "songs.json");
        }

        private void LoadSongs()
        {
            string filePath = GetSongsJsonPath();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("songs.json wurde nicht gefunden:\n" + filePath);
                return;
            }

            string json = File.ReadAllText(filePath);
            songs = JsonSerializer.Deserialize<List<AddSong.Songs>>(json) ?? new List<AddSong.Songs>();

            lb_Table.Items.Clear();
            foreach (var song in songs)
            {
                lb_Table.Items.Add($"{song.title} - {song.artist} ({song.year})");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSongs();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSong addSong = new AddSong();
            addSong.FormClosed += (s, args) => LoadSongs();
            addSong.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lb_Table.SelectedIndex < 0)
            {
                MessageBox.Show("Bitte wähle einen Song aus der Liste aus.");
                return;
            }

            int index = lb_Table.SelectedIndex;
            string songName = lb_Table.Items[index].ToString();

            DialogResult result = MessageBox.Show(
                $"Möchtest du \"{songName}\" wirklich entfernen?",
                "Song entfernen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            songs.RemoveAt(index);

            string filePath = GetSongsJsonPath();
            string newJson = JsonSerializer.Serialize(songs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, newJson);

            LoadSongs();
        }
    }
}
