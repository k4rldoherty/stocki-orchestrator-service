using Microsoft.AspNetCore.Mvc;
using OrchestratorService.Models;
using OrchestratorService.Services;

namespace OrchestratorService.Controllers;

[Route("api/orchestrator")]
[ApiController]
public class StockDataController(StockDataService stockDataService) : ControllerBase
{
    [HttpGet("stock-info-command/{ticker}")]
    public async Task<IActionResult> GetStockInfo(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                "get-stock-info",
                ticker
            );
            if (Response.Data is null)
                return StatusCode(500, Response.Message);
            return Ok(Response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("stock-news-command/{ticker}")]
    public async Task<IActionResult> GetStockNews(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                "get-stock-news",
                ticker
            );
            if (Response.Data is null)
                return StatusCode(500, Response.Message);
            return Ok(Response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("stock-price-data-command/{ticker}")]
    public async Task<IActionResult> GetStockPriceData(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                "get-stock-price-data",
                ticker
            );
            if (Response.Data is null)
                return StatusCode(500, Response.Message);
            return Ok(Response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
