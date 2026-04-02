using FilteringAPI.Models;

namespace FilteringAPI.Services;

public class DatasetService
{
    private readonly string[] artists = { "Avicii", "Martin Garrix", "David Guetta", "Alesso", "Calvin Harris", "Tiësto", "Hardwell", "Afrojack", "Zedd", "Kygo", "Diplo", "Martin Solveig", "Swedish House Mafia", "John Summit", "Fisher" };
    private readonly string[] genres = { "House", "Techno", "Afro", "Trance", "Pop", "Hip-Hop", "Rock", "Afro House", "Tech House", "Deep House", "Progressive House", "Electro House", "Future House", "Bass House", "Psytrance", "Hardstyle" };

    public List<Track> GenerateDataset(int size)
    {
        var rnd = new Random();
        var dataset = new List<Track>(size);

        for (int i = 1; i <= size; i++)
        {
            dataset.Add(new Track
            {
                Id = i,
                Artist = artists[rnd.Next(artists.Length)],
                Title = $"Track {i}",
                Genre = genres[rnd.Next(genres.Length)],
                BPM = rnd.Next(90, 150)
            });
        }

        return dataset;
    }
}