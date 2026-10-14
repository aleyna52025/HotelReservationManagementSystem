# HotelReservationManagementSystem

A hotel management and reservation system built with ASP.NET Core MVC.

## Tech Stack

- ASP.NET Core MVC (.NET 7)
- Entity Framework Core 6 (Code-First + Migrations)
- Microsoft SQL Server

## Features

- Company / partner management
- Category and brand management
- Item (material) catalog with images
- Order management
- Offer (quote) management
- Address management (province/district)
- Status tracking for orders and offers
- User management
- Dashboard overview

## Getting Started

1. Clone the repository
2. Update the connection string in `B2BOdev/appsettings.json`
3. Apply the EF Core migrations:
   ```
   dotnet ef database update
   ```
4. Run the project:
   ```
   dotnet run --project B2BOdev
   ```

## Project Structure

- `Controllers/` — MVC controllers
- `Models/` — Entity classes
- `Data/` — EF Core `DbContext`
- `Migrations/` — EF Core migrations
- `Views/` — Razor views
- `wwwroot/` — Static assets (CSS, JS, images)
