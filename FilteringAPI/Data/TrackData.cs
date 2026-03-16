// using FilteringAPI.Models;

// namespace FilteringAPI.Data
// {
//     public static class TrackData
//     {
//         public static List<Track> Tracks { get; } = GenerateTracks(100000);

//         private static List<Track> GenerateTracks(int count)
//         {
//             var list = new List<Track>();
//             for (int i = 1; i <= count; i++)
//             {
//                 list.Add(new Track
//                 {
//                     Id = i,
//                     Artist = "Artist " + i,
//                     Title = "Track " + i,
//                     Genre = "House",
//                     BPM = 120 + (i % 10)
//                 });
//             }
//             return list;
//         }
//     }
// }