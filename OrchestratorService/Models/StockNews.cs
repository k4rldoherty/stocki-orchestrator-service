using System.Text.Json.Serialization;

namespace OrchestratorService.Models;

public class NewsArticle
{
    [JsonPropertyName("category")]
    public required string Category { get; set; }

    [JsonPropertyName("datetime")]
    public required long DateTimeUnix { get; set; }

    [JsonPropertyName("headline")]
    public required string Headline { get; set; }

    [JsonPropertyName("image")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("summary")]
    public required string Summary { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    public DateTime DateTime =>
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(DateTimeUnix);
}

public class NewsResponse
{
    public required NewsArticle[] Articles { get; set; }
}
