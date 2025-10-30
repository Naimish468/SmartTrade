using TradingApp.Models;

namespace TradingApp.Extensions;

public static class PortfolioExtensions
{
    public static decimal CalculateProfitLoss(this Portfolio portfolio)
    {
        decimal totalProfitLoss = 0;

        foreach (var transaction in portfolio.Transactions)
        {
            if (transaction.Type == TransactionType.Buy)
            {
                // For buy transactions, profit/loss is calculated when sold
                // For now, we'll consider current value vs buy price
                totalProfitLoss -= transaction.Quantity * transaction.Price;
                totalProfitLoss += transaction.Quantity * (transaction.Stock?.CurrentPrice ?? transaction.Price);
            }
            else if (transaction.Type == TransactionType.Sell)
            {
                // For sell transactions, profit/loss is already realized
                // This is a simplified calculation
                totalProfitLoss += transaction.Quantity * transaction.Price;
            }
        }

        return totalProfitLoss;
    }
}