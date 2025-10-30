namespace TradingApp.Models;

public enum TransactionType
{
    Buy,
    Sell
}

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int StockId { get; set; }
    public Stock? Stock { get; set; }
    public TransactionType Type { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime TransactionDate { get; set; }
    public string? Notes { get; set; }
}