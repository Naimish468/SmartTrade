using System.ComponentModel.DataAnnotations;

namespace TradingApp.Models;

public class Portfolio
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Transaction> Transactions { get; set; } = new();
    public decimal TotalValue { get; set; }
    public string? Notes { get; set; }
}