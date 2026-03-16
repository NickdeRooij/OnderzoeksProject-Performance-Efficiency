namespace FilteringAPI.Models;

public class Track
{
    public int Id { get; set; }
    public string Artist { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int BPM { get; set; }
}