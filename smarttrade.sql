-- SmartTrade Database Schema
-- MySQL Database Creation Script

CREATE DATABASE IF NOT EXISTS TradingAppDb;
USE TradingAppDb;

-- Users table
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(255) NOT NULL,
    InvestmentAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PhoneNumber VARCHAR(20) NULL
);

-- Stocks table
CREATE TABLE Stocks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Symbol VARCHAR(10) NOT NULL UNIQUE,
    CompanyName VARCHAR(255) NOT NULL,
    CurrentPrice DECIMAL(18,2) NOT NULL,
    ChangePercent DECIMAL(5,2) NOT NULL DEFAULT 0,
    LastUpdated DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Notes TEXT NULL
);

-- Portfolios table
CREATE TABLE Portfolios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    TotalValue DECIMAL(18,2) NOT NULL DEFAULT 0,
    Notes TEXT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

-- Transactions table
CREATE TABLE Transactions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    StockId INT NOT NULL,
    Type ENUM('Buy', 'Sell') NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Notes TEXT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (StockId) REFERENCES Stocks(Id) ON DELETE CASCADE
);

-- Insert sample stock data
INSERT INTO Stocks (Symbol, CompanyName, CurrentPrice, ChangePercent, LastUpdated) VALUES
('TCS', 'Tata Consultancy Services', 3450.25, 2.15, NOW()),
('INFY', 'Infosys', 1725.80, 1.85, NOW()),
('HDFCBANK', 'HDFC Bank', 1650.50, -0.75, NOW()),
('RELIANCE', 'Reliance Industries', 2890.30, 3.20, NOW()),
('ICICIBANK', 'ICICI Bank', 1125.75, 1.45, NOW()),
('BAJFINANCE', 'Bajaj Finance', 7250.90, -1.20, NOW()),
('HINDUNILVR', 'Hindustan Unilever', 2680.45, 0.95, NOW()),
('ITC', 'ITC', 485.60, 2.80, NOW()),
('MARUTI', 'Maruti Suzuki', 12450.25, -0.50, NOW()),
('KOTAKBANK', 'Kotak Mahindra Bank', 1780.90, 1.65, NOW());

-- Create indexes for better performance
CREATE INDEX idx_users_email ON Users(Email);
CREATE INDEX idx_stocks_symbol ON Stocks(Symbol);
CREATE INDEX idx_transactions_user ON Transactions(UserId);
CREATE INDEX idx_transactions_stock ON Transactions(StockId);
CREATE INDEX idx_portfolios_user ON Portfolios(UserId);

-- Create a sample user (password is 'password123' - in production, use hashed passwords)
INSERT INTO Users (Email, Password, FullName, InvestmentAmount, CreatedAt) VALUES
('demo@smarttrade.com', 'password123', 'Demo User', 100000.00, NOW());