using FilteringAPI.Models;

namespace FilteringAPI.Services;

public class DatasetService
{
    private readonly string[] artists = { "DJ Nick", "Avicii", "Martin Garrix", "Guetta", "Alesso", "Calvin Harris", "Tiësto", "Hardwell", "Afrojack", "Zedd", "Kygo", "Marshmello", "Diplo", "Skrillex", "Martin Solveig", "Swedish House Mafia", "John Summit", "Fisher", "Chris Lake", "Claptone", "Solardo", "Green Velvet", };
    private readonly string[] genres = { "House", "Techno", "Afro", "Trance", "Pop", "Hip-Hop", "R&B", "Rock", "Jazz", "Afro House", "Tech House", "Deep House", "Progressive House", "Electro House", "Future House", "Bass House", "Melodic Techno", "Minimal Techno", "Psytrance", "Hardstyle", "Dubstep", "Drum and Bass" };

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