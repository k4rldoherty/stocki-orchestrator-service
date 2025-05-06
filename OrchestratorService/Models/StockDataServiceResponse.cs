using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrchestratorService.Models;

public class StockDataServiceResponse
{
    [JsonPropertyName("StatusCode")]
    public required int StatusCode;

    [JsonPropertyName("Message")]
    public required string Message;

    [JsonPropertyName("Data")]
    public JsonElement? Data;
}
