using System.ComponentModel.DataAnnotations;

namespace TradingApp.Models;

public class UserRegistration
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Investment amount is required")]
    [Range(1000, 10000000, ErrorMessage = "Investment amount must be between 1,000 and 10,000,000")]
    public decimal InvestmentAmount { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; } = string.Empty;
}