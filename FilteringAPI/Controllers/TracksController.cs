// using Microsoft.AspNetCore.Mvc;
// using FilteringAPI.Models;
// using FilteringAPI.Data;

// namespace FilteringAPI.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class TracksController : ControllerBase
//     {
//         // Endpoint: GET /api/tracks
//         [HttpGet]
//         public IEnumerable<Track> GetAll()
//         {
//             return TrackData.Tracks;
//         }

//         // Endpoint: GET /api/tracks?search=term
//         [HttpGet("search")]
//         public IEnumerable<Track> Search([FromQuery] string search)
//         {
//             if (string.IsNullOrEmpty(search))
//                 return TrackData.Tracks;

//             return TrackData.Tracks
//                 .Where(t => t.Artist.Contains(search, StringComparison.OrdinalIgnoreCase)
//                          || t.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
//         }

//         // [HttpGet]
//         // public IEnumerable<Track> GetTracks()
//         // {
//         //     return GenerateTracks(1000);
//         // }
//     }
// }