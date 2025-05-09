using System.Text.Json;
using OrchestratorService.Models;

namespace OrchestratorService.Services;

public class StockDataService(
    IConfiguration cfg,
    HttpClient client,
    ILogger<StockDataService> logger
)
{
    private readonly string baseUrl =
        cfg.GetSection("StockDataService").Value
        ?? throw new NullReferenceException("Cannot get stock data base url");

    public async Task<OrchestratorResponse> GetStockDataAsync(
        string stockDataServiceEndpoint,
        string ticker
    )
    {
        try
        {
            var url = $"{baseUrl}{stockDataServiceEndpoint}/{ticker.ToUpper()}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new OrchestratorResponse(
                    $"Failed to retrieve stock info: {response.StatusCode}",
                    null
                );
            }

            var resStream = await response.Content.ReadAsStreamAsync();

            if (resStream is null)
                return new OrchestratorResponse("Failed to get data", null);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            dynamic? stockDataServiceResponse = await JsonSerializer.DeserializeAsync<
                Dictionary<string, dynamic>
            >(resStream, options);

            if (stockDataServiceResponse is null)
            {
                logger.LogWarning("stockDataServiceResponse is null");
                return new OrchestratorResponse(
                    "Failed to deserialize stock data service response",
                    null
                );
            }

            return new OrchestratorResponse("Command Succeeded", stockDataServiceResponse);
        }
        catch (HttpRequestException ex)
        {
            return new OrchestratorResponse($"Failed to retrieve stock info: {ex.Message}", null);
        }
        catch (JsonException ex)
        {
            return new OrchestratorResponse(
                $"Failed to deserialize stock data: {ex.Message}",
                null
            );
        }
        catch (Exception ex)
        {
            return new OrchestratorResponse($"{ex.Message}", null);
        }
    }
}
