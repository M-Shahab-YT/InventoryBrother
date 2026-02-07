# InventoryBrother ERP

InventoryBrother ERP is a modern, cross-platform enterprise resource planning system built with **.NET 8** and **Avalonia UI**. It is designed to replace legacy WinForms applications with a robust, scalable architecture supporting both offline (SQLite) and online (SQL Server) databases.

## Features

-   **Dashboard**: Real-time sales metrics, stock alerts, and quick actions.
-   **Point of Sale (POS)**: Fast billing, extensive product search, and thermal printing support.
-   **Inventory Management**: Product tracking, categorization, and low-stock alerts.
-   **HR & Payroll**: Employee management, attendance, and monthly salary processing with auto-calculations.
-   **Procurement**: Purchase order management and supplier tracking.
-   **Finance**: General ledger, expense tracking, and financial statements.
-   **Reporting**: PDF invoice and report generation using QuestPDF.
-   **Security**: Role-based access control with secure BCrypt authentication.

## Prerequisites

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   SQL Server (Optional, for online mode)

## Getting Started

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/YourRepo/InventoryBrother.ERP.git
    cd InventoryBrother.ERP
    ```

2.  **Configuration**:
    -   Update `appsettings.json` in `src/InventoryBrother.Desktop` if you need to switch between SQLite and SQL Server.
    -   Default is **SQLite** (Database will be created automatically on first run).

3.  **Run the Application**:
    ```bash
    dotnet run --project src/InventoryBrother.Desktop
    ```

4.  **Login**:
    -   **Username**: `admin`
    -   **Password**: `admin123`

## Architecture

The solution follows **Clean Architecture** principles:

-   **InventoryBrother.Domain**: Core entities and business logic (No dependencies).
-   **InventoryBrother.Application**: DTOs, Interfaces, and Business Use Cases.
-   **InventoryBrother.Infrastructure**: Implementation of interfaces, EF Core DbContext, Services.
-   **InventoryBrother.Desktop**: UI Layer built with Avalonia (MVVM pattern).

## Building for Release

To create a self-contained single-file executable for Windows:

```powershell
./publish.ps1
```

Or manually:

```bash
dotnet publish src/InventoryBrother.Desktop -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

## License

Proprietary Software. All rights reserved.
