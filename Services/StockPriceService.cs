using System.Net.Http.Json;
using TradingApp.Models;

namespace TradingApp.Services;

public class StockPriceService
{
    private readonly HttpClient _httpClient;

    public StockPriceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.example.com/"); // Replace with actual API
    }

    public async Task<decimal> GetStockPriceAsync(string symbol)
    {
        try
        {
            // Mock API call - replace with actual API endpoint
            // For demo purposes, return a random price
            var random = new Random();
            return await Task.FromResult(Math.Round((decimal)(random.NextDouble() * 5000 + 100), 2));
        }
        catch (Exception)
        {
            // Return a default price if API fails
            return 100.00m;
        }
    }

    public async Task<List<Stock>> GetAllStocksAsync()
    {
        // Mock data for demonstration
        var stocks = new List<Stock>
        {
            new Stock { Id = 1, Symbol = "TCS", CompanyName = "Tata Consultancy Services", CurrentPrice = 3450.25m, ChangePercent = 2.15m, LastUpdated = DateTime.Now },
            new Stock { Id = 2, Symbol = "INFY", CompanyName = "Infosys", CurrentPrice = 1725.80m, ChangePercent = 1.85m, LastUpdated = DateTime.Now },
            new Stock { Id = 3, Symbol = "HDFCBANK", CompanyName = "HDFC Bank", CurrentPrice = 1650.50m, ChangePercent = -0.75m, LastUpdated = DateTime.Now },
            new Stock { Id = 4, Symbol = "RELIANCE", CompanyName = "Reliance Industries", CurrentPrice = 2890.30m, ChangePercent = 3.20m, LastUpdated = DateTime.Now },
            new Stock { Id = 5, Symbol = "ICICIBANK", CompanyName = "ICICI Bank", CurrentPrice = 1125.75m, ChangePercent = 1.45m, LastUpdated = DateTime.Now },
            new Stock { Id = 6, Symbol = "BAJFINANCE", CompanyName = "Bajaj Finance", CurrentPrice = 7250.90m, ChangePercent = -1.20m, LastUpdated = DateTime.Now },
            new Stock { Id = 7, Symbol = "HINDUNILVR", CompanyName = "Hindustan Unilever", CurrentPrice = 2680.45m, ChangePercent = 0.95m, LastUpdated = DateTime.Now },
            new Stock { Id = 8, Symbol = "ITC", CompanyName = "ITC", CurrentPrice = 485.60m, ChangePercent = 2.80m, LastUpdated = DateTime.Now },
            new Stock { Id = 9, Symbol = "MARUTI", CompanyName = "Maruti Suzuki", CurrentPrice = 12450.25m, ChangePercent = -0.50m, LastUpdated = DateTime.Now },
            new Stock { Id = 10, Symbol = "KOTAKBANK", CompanyName = "Kotak Mahindra Bank", CurrentPrice = 1780.90m, ChangePercent = 1.65m, LastUpdated = DateTime.Now }
        };

        return await Task.FromResult(stocks);
    }
}