using System.Text.Json;
using OrchestratorService.Models;

namespace OrchestratorService.Services;

public class StockDataService(IConfiguration cfg, HttpClient client)
{
    private readonly string baseUrl =
        cfg.GetSection("StockDataService").Value
        ?? throw new NullReferenceException("Cannot get stock data base url");

    public async Task<OrchestratorResponse> GetStockInfoAsync(string ticker)
    {
        var url = baseUrl + "/get-stock-info" + "/ticker";
        var res = await client.GetAsync(url);
        var obj = JsonSerializer.Deserialize<StockDataServiceResponse>(
            await res.Content.ReadAsStringAsync()
        );
        if (obj is null)
        {
            return new OrchestratorResponse("Something went wrong retriving the data", null);
        }
        if (obj.Data is null)
        {
            return new OrchestratorResponse(obj.Message, null);
        }
        return new OrchestratorResponse("Command Succeeded", null);
    }
}
