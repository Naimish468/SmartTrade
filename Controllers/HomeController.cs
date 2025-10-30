using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TradingApp.Models;
using TradingApp.Services;
using TradingApp.Extensions;

namespace TradingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StockPriceService _stockPriceService;
    private readonly IMemoryCache _cache;

    public HomeController(ILogger<HomeController> logger, StockPriceService stockPriceService, IMemoryCache cache)
    {
        _logger = logger;
        _stockPriceService = stockPriceService;
        _cache = cache;
    }

    public IActionResult Index()
    {
        var currentTime = DateTime.Now;
        var greeting = currentTime.Hour < 12 ? "Good Morning Traders!" : "Good Evening Investors!";
        ViewBag.Greeting = greeting;
        return View("MyView");
    }

    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> Welcome()
    {
        // Check cache for top gainers/losers
        if (!_cache.TryGetValue("TopStocks", out List<Stock> stocks))
        {
            stocks = await _stockPriceService.GetAllStocksAsync();
            _cache.Set("TopStocks", stocks, TimeSpan.FromMinutes(5));
        }

        ViewData["Stocks"] = stocks;
        ViewBag.Message = "Welcome to your trading dashboard!";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
