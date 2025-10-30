namespace TradingApp.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public decimal InvestmentAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? PhoneNumber { get; set; }
}