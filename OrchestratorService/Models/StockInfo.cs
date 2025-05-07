using System.Text.Json.Serialization;

namespace OrchestratorService.Models;

public class StockInfo
{
    [JsonPropertyName("Symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("AssetType")]
    public string AssetType { get; set; } = string.Empty;

    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("Sector")]
    public string Sector { get; set; } = string.Empty;

    [JsonPropertyName("Industry")]
    public string Industry { get; set; } = string.Empty;

    [JsonPropertyName("MarketCapitalization")]
    public decimal MarketCapitalization { get; set; }

    [JsonPropertyName("EBITDA")]
    public decimal EBITDA { get; set; }

    [JsonPropertyName("PERatio")]
    public decimal PERatio { get; set; }

    [JsonPropertyName("PEGRatio")]
    public decimal PEGRatio { get; set; }

    [JsonPropertyName("BookValue")]
    public decimal BookValue { get; set; }

    [JsonPropertyName("DividendPerShare")]
    public decimal DividendPerShare { get; set; }

    [JsonPropertyName("DividendYield")]
    public decimal DividendYield { get; set; }

    [JsonPropertyName("EPS")]
    public decimal EPS { get; set; }

    [JsonPropertyName("RevenuePerShareTTM")]
    public decimal RevenuePerShareTTM { get; set; }

    [JsonPropertyName("ProfitMargin")]
    public decimal ProfitMargin { get; set; }

    [JsonPropertyName("OperatingMarginTTM")]
    public decimal OperatingMarginTTM { get; set; }

    [JsonPropertyName("ReturnOnAssetsTTM")]
    public decimal ReturnOnAssetsTTM { get; set; }

    [JsonPropertyName("ReturnOnEquityTTM")]
    public decimal ReturnOnEquityTTM { get; set; }

    [JsonPropertyName("RevenueTTM")]
    public decimal RevenueTTM { get; set; }

    [JsonPropertyName("GrossProfitTTM")]
    public decimal GrossProfitTTM { get; set; }

    [JsonPropertyName("DilutedEPSTTM")]
    public decimal DilutedEPSTTM { get; set; }

    [JsonPropertyName("QuarterlyEarningsGrowthYOY")]
    public decimal QuarterlyEarningsGrowthYOY { get; set; }

    [JsonPropertyName("QuarterlyRevenueGrowthYOY")]
    public decimal QuarterlyRevenueGrowthYOY { get; set; }

    [JsonPropertyName("AnalystTargetPrice")]
    public decimal AnalystTargetPrice { get; set; }

    [JsonPropertyName("AnalystRatingStrongBuy")]
    public string AnalystRatingStrongBuy { get; set; } = string.Empty;

    [JsonPropertyName("AnalystRatingBuy")]
    public string AnalystRatingBuy { get; set; } = string.Empty;

    [JsonPropertyName("AnalystRatingHold")]
    public string AnalystRatingHold { get; set; } = string.Empty;

    [JsonPropertyName("AnalystRatingSell")]
    public string AnalystRatingSell { get; set; } = string.Empty;

    [JsonPropertyName("AnalystRatingStrongSell")]
    public string AnalystRatingStrongSell { get; set; } = string.Empty;

    [JsonPropertyName("TrailingPE")]
    public decimal TrailingPE { get; set; }

    [JsonPropertyName("ForwardPE")]
    public decimal ForwardPE { get; set; }

    [JsonPropertyName("PriceToSalesRatioTTM")]
    public decimal PriceToSalesRatioTTM { get; set; }

    [JsonPropertyName("PriceToBookRatio")]
    public decimal PriceToBookRatio { get; set; }

    [JsonPropertyName("EVToRevenue")]
    public decimal EVToRevenue { get; set; }

    [JsonPropertyName("EVToEBITDA")]
    public decimal EVToEBITDA { get; set; }

    [JsonPropertyName("Beta")]
    public decimal Beta { get; set; }

    [JsonPropertyName("52WeekHigh")]
    public decimal FiftyTwoWeekHigh { get; set; }

    [JsonPropertyName("52WeekLow")]
    public decimal FiftyTwoWeekLow { get; set; }

    [JsonPropertyName("50DayMovingAverage")]
    public decimal FiftyDayMovingAverage { get; set; }

    [JsonPropertyName("200DayMovingAverage")]
    public decimal TwoHundredDayMovingAverage { get; set; }

    [JsonPropertyName("SharesOutstanding")]
    public long SharesOutstanding { get; set; }
}
