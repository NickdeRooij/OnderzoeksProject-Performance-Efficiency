using FilteringAPI.Models;
using FilteringAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// CORS instellen
// --------------------
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://127.0.0.1:3000", "http://localhost:5500") // Live Server origin
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// CORS middleware toevoegen
app.UseCors();

// Maak DatasetService
var datasetService = new DatasetService();

// Genereer datasets
var datasets = new Dictionary<string, List<Track>>
{
    { "small", datasetService.GenerateDataset(1_000) },
    { "medium", datasetService.GenerateDataset(10_000) },
    { "large", datasetService.GenerateDataset(100_000) },
    { "xlarge", datasetService.GenerateDataset(1_000_000) }
};

// ====================
// Variant A: Client-side filtering
// ====================
app.MapGet("/dataset/client/{size}", (string size) =>
{
    if (!datasets.ContainsKey(size.ToLower()))
        return Results.NotFound("Dataset niet gevonden");

    return Results.Ok(datasets[size.ToLower()]); // hele dataset naar browser
});

// ====================
// Variant B: Server-side filtering
// ====================
app.MapGet("/dataset/server/{size}", (string size, string? artist, string? genre, int? minBPM, int? maxBPM) =>
{
    if (!datasets.ContainsKey(size.ToLower()))
        return Results.NotFound("Dataset niet gevonden");

    var query = datasets[size.ToLower()].AsQueryable();

    if (!string.IsNullOrEmpty(artist))
        query = query.Where(t => t.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrEmpty(genre))
        query = query.Where(t => t.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

    if (minBPM.HasValue)
        query = query.Where(t => t.BPM >= minBPM.Value);

    if (maxBPM.HasValue)
        query = query.Where(t => t.BPM <= maxBPM.Value);

    return Results.Ok(query.ToList());
});

app.Run();