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
        public class Songs
        {
            public string title { get; set; }
            public string artist { get; set; }
            public string year { get; set; }
        }

        private string GetSongsJsonPath()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);

            while (dir != null)
            {
                string possiblePath = Path.Combine(dir.FullName, "songs.json");

                if (File.Exists(possiblePath))
                {
                    return possiblePath;
                }

                dir = dir.Parent;
            }

            return Path.Combine(Application.StartupPath, "songs.json");
        }

        public void LoadSongs()
        {
            //Load Songs from songs.json and display them in the ListBox
            
            lb_Table.Items.Clear();

            string filePath = GetSongsJsonPath();

            if (!File.Exists(filePath))
            {
                lb_Table.Items.Add("songs.json wurde nicht gefunden:\n" + filePath);
                return;
            }

            string json = File.ReadAllText(filePath);

            List<Songs> songs = JsonSerializer.Deserialize<List<Songs>>(json) ?? new List<Songs>();

            foreach (var song in songs)
            {
                lb_Table.Items.Add($"{song.title} - {song.artist} ({song.year})");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSongs();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSong addSong = new AddSong(this);
            addSong.Show();
        }
    }
}
