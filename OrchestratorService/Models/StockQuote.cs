using System.Text.Json.Serialization;

namespace OrchestratorService.Models;

public class StockQuote
{
    [JsonPropertyName("c")]
    public decimal Close { get; set; }

    [JsonPropertyName("h")]
    public decimal High { get; set; }

    [JsonPropertyName("l")]
    public decimal Low { get; set; }

    [JsonPropertyName("o")]
    public decimal Open { get; set; }

    [JsonPropertyName("pc")]
    public decimal PreviousClose { get; set; }

    [JsonPropertyName("t")]
    public long Timestamp { get; set; }

    public DateTime Date =>
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Timestamp);
}
