using Microsoft.AspNetCore.Mvc;
using TradingApp.Data;
using TradingApp.Models;

namespace TradingApp.Controllers;

public class AccountController : Controller
{
    private readonly TradingContext _context;

    public AccountController(TradingContext context)
    {
        _context = context;
    }

    // GET: Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegistration model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password, // In production, hash the password
                FullName = model.FullName,
                InvestmentAmount = model.InvestmentAmount,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Registration successful! Welcome to SmartTrade.";

            return RedirectToAction("Welcome", "Home");
        }

        return View(model);
    }

    // GET: Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetInt32("UserId", user.Id);

            TempData["SuccessMessage"] = $"Welcome back, {user.FullName}!";

            return RedirectToAction("Welcome", "Home");
        }

        ModelState.AddModelError("", "Invalid email or password");
        return View();
    }

    // POST: Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["SuccessMessage"] = "You have been logged out successfully.";

        return RedirectToAction("Index", "Home");
    }

    // GET: Account/Profile
    public IActionResult Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToAction("Login");
        }

        var user = _context.Users.Find(userId);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
}