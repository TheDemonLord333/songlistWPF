using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Songliste
{
    public static class SongService
    {
        private static string _cachedPath;

        public static string GetSongsJsonPath()
        {
            if (_cachedPath != null) return _cachedPath;

            string dir = AppDomain.CurrentDomain.BaseDirectory;
            while (dir != null)
            {
                string candidate = Path.Combine(dir, "songs.json");
                if (File.Exists(candidate))
                {
                    _cachedPath = candidate;
                    return candidate;
                }
                dir = Directory.GetParent(dir)?.FullName;
            }
            return null;
        }

        public static List<Song> LoadSongs()
        {
            string path = GetSongsJsonPath();
            if (path == null || !File.Exists(path)) return new List<Song>();
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Song>>(json) ?? new List<Song>();
        }

        public static void SaveSongs(List<Song> songs)
        {
            string path = GetSongsJsonPath();
            if (path == null) return;
            string json = JsonSerializer.Serialize(songs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
