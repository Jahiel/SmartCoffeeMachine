# Smart Coffee Machine Backend

## Overview

This project implements the backend for a smart coffee machine system. The application exposes a RESTful API to control a physical coffee machine, track its usage, and report its current status and alerts. It is designed following SOLID principles and clean architecture, ensuring scalability and maintainability for future enhancements.

The backend is built with **ASP.NET Core**, with a clean separation of concerns using **MVC architecture**. Data persistence is managed through **Entity Framework Core** and a relational database (SQL Server or SQLite for development).

---

## Features

- Log and persist all actions and usage statistics
- Display current machine state and alerts
- Control the coffee machine (Turn On, Turn Off, Make Coffee)
- RESTful API to expose all relevant functionality
- Utilization statistics:
  - First and last cup time per day
  - Average cups per day and per hour
- Robust and scalable data model

---

## Technology Stack

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core (Code First)
- SQL Server / SQLite
- AutoMapper
- Swagger for API documentation

---

## Getting Started

### Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- SQL Server (or use SQLite in development)
- Optional: Visual Studio 2022 or VS Code

### Setup

1. **Clone the repository**  
   ```bash
   git clone https://your-repo-url.git
   cd SmartCoffeeMachineBackend
   ```

2. **Set up the database**
   - Configure your connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=coffee.db"
     }
     ```
   - Run migrations:
     ```bash
     dotnet ef database update
     ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access API documentation**
   - Navigate to [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## Project Structure

```
SmartCoffeeMachine/
├── Controllers/         # API endpoints
├── Services/            # Business logic
├── Repositories/        # Data access layer
├── Models/              # Domain models
├── DTOs/                # Data Transfer Objects
├── Migrations/          # EF Core migrations
├── Interfaces/          # Interfaces for abstraction and DI
├── Logging/             # Logging and auditing logic
├── Program.cs           # Entry point
└── appsettings.json     # Configuration
```

---

## API Endpoints (Summary)

| Endpoint                          | Method | Description                    |
|----------------------------------|--------|--------------------------------|
| `/api/machine/state`             | GET    | Get current machine state      |
| `/api/machine/alerts`            | GET    | Get current alerts             |
| `/api/machine/action/on`         | POST   | Turn on machine                |
| `/api/machine/action/off`        | POST   | Turn off machine               |
| `/api/machine/action/makecoffee` | POST   | Make a cup of coffee           |
| `/api/utilisation/daily`         | GET    | Daily cup statistics           |
| `/api/utilisation/hourly`        | GET    | Hourly cup statistics          |

Full documentation available via Swagger.

---

## How to Prioritize Tasks

### Critical (First)
- Design domain models and integrate ICoffeeMachine interface
- Implement REST endpoints for core machine actions
- Implement logging and persistence of usage

### Important (Second)
- Implement alert/status system
- Basic web UI integration (status + control)
- Usage analytics: daily/hourly stats

### Optional / Future
- Advanced analytics (e.g., trends, charts)
- Notifications or real-time updates (SignalR)
- Admin dashboard for maintenance
- Multitenancy / multi-machine support

---

## License

This project is licensed under the **GNU GENERAL PUBLIC LICENSE Version 3, 29 June 2007**. See `LICENCE.TXT` for full license text.

