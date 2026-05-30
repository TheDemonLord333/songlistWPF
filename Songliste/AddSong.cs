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
    public partial class AddSong : Form
    {

        public class Songs
        {
            public string title { get; set; }
            public string artist { get; set; }
            [System.Text.Json.Serialization.JsonConverter(typeof(IntOrStringConverter))]
            public int year { get; set; }
        }

        public class IntOrStringConverter : System.Text.Json.Serialization.JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                    return int.Parse(reader.GetString());
                return reader.GetInt32();
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
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

        public AddSong()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string filePath = GetSongsJsonPath();

            if (!File.Exists(filePath)) 
            {
                MessageBox.Show("songs.json wurde nicht gefunden:\n" + filePath);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Title.Text)) 
            {
                MessageBox.Show("Bitte gib einen Titel ein.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_artist.Text))
            {
                MessageBox.Show("Bitte gib einen Artist ein.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_year.Text))
            {
                MessageBox.Show("Bitte gib ein Jahr ein.");
                return;
            }

            string json = File.ReadAllText(filePath);

            List<Songs> songs = JsonSerializer.Deserialize<List<Songs>>(json) ?? new List<Songs>();

            songs.Add(new Songs
            {
                title = txt_Title.Text,
                artist = txt_artist.Text,
                year = int.Parse(txt_year.Text)
            });

            string newJson = JsonSerializer.Serialize(songs, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, newJson);
        }

        private void showPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = Path.Combine(
                Directory.GetParent(Application.StartupPath).Parent.Parent.FullName,
                "songs.json"
            );

            MessageBox.Show(filePath);
        }
    }
}
