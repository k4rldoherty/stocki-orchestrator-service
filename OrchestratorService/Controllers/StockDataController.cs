using Microsoft.AspNetCore.Mvc;
using OrchestratorService.Models;
using OrchestratorService.Services;

namespace MyApp.Namespace
{
    [Route("api/")]
    [ApiController]
    public class StockDataController(StockDataService stockDataService) : ControllerBase
    {
        [HttpGet("stock-info/{ticker}")]
        public async Task<OrchestratorResponse> GetStockInfo(string ticker)
        {
            if (ticker is null)
            {
                return new OrchestratorResponse("Incorrect ticker", null);
            }
            var res = await stockDataService.GetStockInfoAsync(ticker);
            return res;
        }
    }
}
