using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryBrother.Infrastructure.Data;

/// <summary>
/// Database configuration with support for online (SQL Server) and offline (SQLite) modes.
/// Includes performance optimizations for large datasets (1GB+, 20 years of data).
/// </summary>
public class DatabaseConfiguration
{
    public DatabaseMode Mode { get; set; } = DatabaseMode.Online;
    public string SqlServerConnectionString { get; set; } = string.Empty;
    public string SqliteDbPath { get; set; } = "InventoryBrother.db";
    
    /// <summary>
    /// Configure EF Core DbContext with appropriate provider based on mode
    /// </summary>
    public void ConfigureDbContext(DbContextOptionsBuilder options)
    {
        switch (Mode)
        {
            case DatabaseMode.Offline:
                ConfigureSqlite(options);
                break;
            case DatabaseMode.Online:
            default:
                ConfigureSqlServer(options);
                break;
        }
    }
    
    private void ConfigureSqlServer(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(SqlServerConnectionString, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(3);
            sqlOptions.CommandTimeout(60);
        });
    }
    
    private void ConfigureSqlite(DbContextOptionsBuilder options)
    {
        var connectionString = $"Data Source={SqliteDbPath}";
        options.UseSqlite(connectionString, sqliteOptions =>
        {
            sqliteOptions.CommandTimeout(60);
        });
    }
}

/// <summary>
/// SQLite performance optimizer - applies PRAGMA settings for optimal performance
/// with large datasets (1GB+)
/// </summary>
public static class SqliteOptimizer
{
    /// <summary>
    /// Apply critical PRAGMA settings for performance:
    /// - WAL mode: 2-20x faster writes, concurrent reads
    /// - 64MB cache for in-memory data
    /// - Memory-mapped I/O for faster reads
    /// - Temp tables stored in RAM
    /// </summary>
    public static void ConfigureForPerformance(SqliteConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
        
        using var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            PRAGMA journal_mode = WAL;
            PRAGMA synchronous = NORMAL;
            PRAGMA cache_size = -64000;
            PRAGMA temp_store = MEMORY;
            PRAGMA mmap_size = 268435456;
            PRAGMA page_size = 4096;
            PRAGMA auto_vacuum = INCREMENTAL;
        ";
        cmd.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Create performance-critical indexes for common queries
    /// </summary>
    public static void CreatePerformanceIndexes(SqliteConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
        
        using var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            -- Stock queries
            CREATE INDEX IF NOT EXISTS IX_Stock_ProductCode ON IMIS_tblStock(ProductCode);
            CREATE INDEX IF NOT EXISTS IX_Stock_ExpiryDate ON IMIS_tblStock(ExpiryDate);
            CREATE INDEX IF NOT EXISTS IX_Stock_StoreID ON IMIS_tblStock(StoreID);
            CREATE INDEX IF NOT EXISTS IX_Stock_Composite ON IMIS_tblStock(StoreID, ProductCode, ExpiryDate);
            
            -- Product queries
            CREATE INDEX IF NOT EXISTS IX_Product_Barcode ON IMIS_tblProduct(ProductBarCode);
            CREATE INDEX IF NOT EXISTS IX_Product_Category ON IMIS_tblProduct(ProductCategoryID);
            CREATE INDEX IF NOT EXISTS IX_Product_Name ON IMIS_tblProduct(ProductName);
            
            -- Sales queries
            CREATE INDEX IF NOT EXISTS IX_SaleOrderMain_Date ON IMIS_tblSaleOrderMain(SaleOrderDate);
            CREATE INDEX IF NOT EXISTS IX_SaleOrderMain_Customer ON IMIS_tblSaleOrderMain(CustomerID);
            CREATE INDEX IF NOT EXISTS IX_SaleOrderDetail_InvoiceNo ON IMIS_tblSaleOrderDetail(InvoiceNo);
            
            -- Purchase queries
            CREATE INDEX IF NOT EXISTS IX_PurchaseOrderMain_Date ON IMIS_tblPurchaseOrderMain(PurchaseOrderDate);
            CREATE INDEX IF NOT EXISTS IX_PurchaseOrderMain_Supplier ON IMIS_tblPurchaseOrderMain(SupplierID);
            
            -- Customer/Supplier statements
            CREATE INDEX IF NOT EXISTS IX_CustomerStatement_Customer ON FMIS_tblCustomerStatement(CustomerID);
            CREATE INDEX IF NOT EXISTS IX_SupplierStatement_Supplier ON FMIS_tblSupplierStatement(SupplierID);
        ";
        cmd.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Run VACUUM and ANALYZE to optimize database performance
    /// Should be run periodically (e.g., weekly) or after bulk operations
    /// </summary>
    public static void OptimizeDatabase(SqliteConnection connection)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();
        
        using var cmd = connection.CreateCommand();
        cmd.CommandText = @"
            PRAGMA incremental_vacuum;
            ANALYZE;
        ";
        cmd.ExecuteNonQuery();
    }
}

public enum DatabaseMode
{
    Online,   // SQL Server
    Offline   // SQLite
}
