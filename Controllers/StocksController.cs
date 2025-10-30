using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingApp.Data;
using TradingApp.Models;

namespace TradingApp.Controllers;

public class StocksController : Controller
{
    private readonly TradingContext _context;

    public StocksController(TradingContext context)
    {
        _context = context;
    }

    // GET: Stocks
    public async Task<IActionResult> Index()
    {
        return View(await _context.Stocks.ToListAsync());
    }

    // GET: Stocks/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stocks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (stock == null)
        {
            return NotFound();
        }

        return View(stock);
    }

    // GET: Stocks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Stocks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Symbol,CompanyName,CurrentPrice,ChangePercent,LastUpdated,Notes")] Stock stock)
    {
        if (ModelState.IsValid)
        {
            _context.Add(stock);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Stock created successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(stock);
    }

    // GET: Stocks/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        return View(stock);
    }

    // POST: Stocks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Symbol,CompanyName,CurrentPrice,ChangePercent,LastUpdated,Notes")] Stock stock)
    {
        if (id != stock.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(stock);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Stock updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(stock.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(stock);
    }

    // GET: Stocks/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stocks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (stock == null)
        {
            return NotFound();
        }

        return View(stock);
    }

    // POST: Stocks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);
        if (stock != null)
        {
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Stock deleted successfully!";
        }

        return RedirectToAction(nameof(Index));
    }

    private bool StockExists(int id)
    {
        return _context.Stocks.Any(e => e.Id == id);
    }
}