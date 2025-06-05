using Microsoft.AspNetCore.Mvc;
using OrchestratorService.Models;
using OrchestratorService.Services;

namespace OrchestratorService.Controllers;

[Route("api/v1/slash-commands")]
[ApiController]
public class SlashCommandsController(StockDataService stockDataService) : ControllerBase
{
    [HttpGet("info")]
    public async Task<IActionResult> GetStockInfo([FromQuery] string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                $"stock-info?ticker={ticker.ToUpper()}",
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

    [HttpGet("news")]
    public async Task<IActionResult> GetStockNews([FromQuery] string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                $"stock-news?ticker={ticker.ToUpper()}",
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

    [HttpGet("price-data")]
    public async Task<IActionResult> GetStockPriceData([FromQuery] string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return BadRequest("Invalid ticker");

        if (!ModelState.IsValid)
            return BadRequest("Model State Not Valid");

        try
        {
            OrchestratorResponse Response = await stockDataService.GetStockDataAsync(
                $"stock-price-data?ticker={ticker.ToUpper()}",
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
