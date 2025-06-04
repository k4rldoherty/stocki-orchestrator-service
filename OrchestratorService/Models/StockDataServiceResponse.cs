using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrchestratorService.Models;

public class StockDataServiceResponse
{
    [JsonPropertyName("statusCode")]
    public required int StatusCode;

    [JsonPropertyName("message")]
    public required string Message;

    [JsonPropertyName("data")]
    public JsonElement? Data;
}
