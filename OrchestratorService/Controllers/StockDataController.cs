using Microsoft.AspNetCore.Mvc;
// using OrchestratorService.Models;
using OrchestratorService.Services;

namespace MyApp.Namespace
{
    [Route("api/orchestrator")]
    [ApiController]
    public class StockDataController(StockDataService stockDataService) : ControllerBase
    {
        [HttpGet("stock-info-command/{ticker}")]
        public async Task<IActionResult> GetStockInfo(string ticker)
        {
            if (string.IsNullOrWhiteSpace(ticker))
            {
                return BadRequest("Invalid ticker");
            }

            try
            {
                var stockInfoResponse = await stockDataService.GetStockInfoAsync(ticker);
                return Ok(stockInfoResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
