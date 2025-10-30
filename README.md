# SmartTrade - ASP.NET Core MVC Trading Portal

A comprehensive demo stock trading portal built with ASP.NET Core MVC, showcasing modern web development practices and practical implementation of various .NET concepts.

## 🚀 Features

### Core MVC Features
- **Model-View-Controller Architecture**: Clean separation of concerns
- **Time-based Greetings**: Dynamic welcome messages based on current time
- **Bootstrap UI**: Responsive design with Bootstrap 5 styling
- **Navigation**: Seamless page transitions with ASP.NET Core routing

### Data Management
- **Entity Framework Core**: Code First approach with MySQL integration
- **CRUD Operations**: Complete Create, Read, Update, Delete functionality for stocks
- **Data Validation**: Client and server-side validation with Data Annotations
- **Nullable Types**: Proper handling of optional data fields

### Advanced Features
- **Asynchronous Programming**: Async methods for API calls and data fetching
- **Caching**: Response caching and IMemoryCache for performance optimization
- **Session Management**: User session handling for login state
- **Cookie Management**: Theme preferences and user settings
- **Query String Handling**: URL parameter passing for stock symbols
- **Hidden Fields**: Form data management

### API Integration
- **RESTful Web API**: Full CRUD endpoints for stocks and transactions
- **Stock Price Service**: Asynchronous API calls for real-time data
- **Extension Methods**: Custom portfolio calculations

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: MySQL (with EF Core)
- **Frontend**: Bootstrap 5, HTML5, CSS3
- **Backend**: C# 12, Entity Framework Core
- **Tools**: dotnet CLI, MySQL Workbench

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (or use SQLite for development)
- [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio

## 🚀 Quick Start

### 1. Clone and Setup
```bash
# Navigate to project directory
cd TradingApp

# Restore packages
dotnet restore
```

### 2. Database Setup

#### Option A: MySQL (Recommended)
```bash
# Install MySQL and run the provided SQL script
mysql -u root -p < ../smarttrade.sql
```

#### Option B: SQLite (Quick Setup)
```bash
# Add SQLite package
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

# Update appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=TradingApp.db"
  }
}
```

### 3. Run the Application
```bash
# Build and run
dotnet build
dotnet run
```

### 4. Access the Application
- **Home Page**: http://localhost:5000
- **Dashboard**: http://localhost:5000/Home/Welcome
- **Stock Management**: http://localhost:5000/Stocks
- **User Registration**: http://localhost:5000/Account/Register

## 📁 Project Structure

```
TradingApp/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs      # Main pages
│   ├── AccountController.cs   # User management
│   ├── StocksController.cs    # Stock CRUD
│   └── TransactionsController.cs # API endpoints
├── Models/               # Data Models
│   ├── Stock.cs
│   ├── User.cs
│   ├── Portfolio.cs
│   ├── Transaction.cs
│   └── UserRegistration.cs
├── Views/                # Razor Views
│   ├── Home/
│   ├── Account/
│   └── Stocks/
├── Data/                 # Database Context
│   └── TradingContext.cs
├── Services/             # Business Logic
│   └── StockPriceService.cs
├── Extensions/           # Extension Methods
│   └── PortfolioExtensions.cs
├── wwwroot/              # Static Files
├── appsettings.json      # Configuration
└── Program.cs           # Application Entry Point
```

## 🎯 Practical Topics Covered

This project demonstrates all the practical topics from the assignment:

1. ✅ **MVC Project Creation** - Ports 5000/5001 configured
2. ✅ **HomeController & Custom View** - Time-based greetings
3. ✅ **Navigation with asp-action** - Dashboard button
4. ✅ **Bootstrap Tables** - Stock data display
5. ✅ **Models with Nullable Types** - Optional fields
6. ✅ **Global Usings** - Clean imports
7. ✅ **Extension Methods** - Portfolio calculations
8. ✅ **Async API Calls** - Stock price fetching
9. ✅ **State Management** - Session, Cookies, QueryString, Hidden Fields
10. ✅ **Caching** - ResponseCache and IMemoryCache
11. ✅ **EF Core Code First** - MySQL database setup
12. ✅ **Web API CRUD** - RESTful endpoints
13. ✅ **ViewData/ViewBag/TempData** - Data transfer
14. ✅ **Model Validation** - Registration form validation
15. ✅ **CRUD Forms** - Complete stock management

## 🔧 Configuration

### Database Connection
Update `appsettings.json` for your database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TradingAppDb;User=root;Password=your_password;"
  }
}
```

### Ports Configuration
Modify `Program.cs` to change ports:

```csharp
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");
```

## 🧪 Testing

### API Endpoints
- `GET /api/stocks` - Get all stocks
- `POST /api/transactions` - Create transaction
- `PUT /api/stocks/{id}` - Update stock
- `DELETE /api/stocks/{id}` - Delete stock

### Sample Data
- **Demo User**: demo@smarttrade.com / password123
- **Stocks**: 10 pre-loaded Indian stocks (TCS, Infosys, etc.)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is for educational purposes. Feel free to use and modify as needed.

## 📞 Support

Contact: 23amtics468@gmail.com

---


**Built By Naimish**
