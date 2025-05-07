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

    public async Task<OrchestratorResponse> GetStockInfoAsync(string ticker)
    {
        try
        {
            var url = $"{baseUrl}get-stock-info/{ticker.ToUpper()}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new OrchestratorResponse(
                    $"Failed to retrieve stock info: {response.StatusCode}",
                    null
                );
            }

            // TODO: PROBLEM HERE WITH PARSING JSON DATA
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var stockDataServiceResponse = JsonSerializer.Deserialize<StockDataServiceResponse>(
                await response.Content.ReadAsStreamAsync(),
                options
            );

            if (stockDataServiceResponse is null)
            {
                logger.LogWarning("stockDataServiceResponse is null");
                return new OrchestratorResponse(
                    "Failed to deserialize stock data service response",
                    null
                );
            }

            if (stockDataServiceResponse.Data is null)
            {
                return new OrchestratorResponse(stockDataServiceResponse.Message, null);
            }

            var stockInfoObj = JsonSerializer.Deserialize<StockInfo>(
                stockDataServiceResponse.Data.GetValueOrDefault()
            );

            return new OrchestratorResponse("Command Succeeded", stockInfoObj);
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
