using Microsoft.EntityFrameworkCore;
using TradingApp.Models;

namespace TradingApp.Data;

public class TradingContext : DbContext
{
    public TradingContext(DbContextOptions<TradingContext> options) : base(options) { }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Portfolio>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Stock)
            .WithMany()
            .HasForeignKey(t => t.StockId);

        // Seed data
        modelBuilder.Entity<Stock>().HasData(
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
        );
    }
}