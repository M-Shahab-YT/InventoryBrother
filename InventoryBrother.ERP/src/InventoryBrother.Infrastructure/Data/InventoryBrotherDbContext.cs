using System;
using System.Collections.Generic;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Data;

public partial class InventoryBrotherDbContext : DbContext
{
    public InventoryBrotherDbContext()
    {
    }

    public InventoryBrotherDbContext(DbContextOptions<InventoryBrotherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }
    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }
    public virtual DbSet<AspnetPath> AspnetPaths { get; set; }
    public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }
    public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }
    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }
    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }
    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }
    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }
    public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

    public virtual DbSet<DoctorInformation> DoctorInformations { get; set; }
    public virtual DbSet<CashAccount> CashAccounts { get; set; }
    public virtual DbSet<CashAccountTransaction> CashAccountTransactions { get; set; }
    public virtual DbSet<CashierBalance> CashierBalances { get; set; }
    public virtual DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
    public virtual DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }
    public virtual DbSet<CustomerStatement> CustomerStatements { get; set; }
    public virtual DbSet<EmployeeAdvanceSalary> EmployeeAdvanceSalaries { get; set; }
    public virtual DbSet<ExpenseDetail> ExpenseDetails { get; set; }
    public virtual DbSet<ExpenseHead> ExpenseHeads { get; set; }
    public virtual DbSet<FinancialYear> FinancialYears { get; set; }
    public virtual DbSet<FinancialYearMonth> FinancialYearMonths { get; set; }
    public virtual DbSet<Payroll> Payrolls { get; set; }
    public virtual DbSet<Revenue> Revenues { get; set; }
    public virtual DbSet<RevenueSetting> RevenueSettings { get; set; }
    public virtual DbSet<RevenueType> RevenueTypes { get; set; }
    public virtual DbSet<SalesmanStatement> SalesmanStatements { get; set; }
    public virtual DbSet<SupplierStatement> SupplierStatements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<PayrollMonth> PayrollMonths { get; set; }
    public virtual DbSet<AveragePrice> AveragePrices { get; set; }
    public virtual DbSet<BarcodeLabelSetting> BarcodeLabelSettings { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<StockDamage> StockDamages { get; set; }
    public virtual DbSet<DatabaseBackupSetting> DatabaseBackupSettings { get; set; }
    public virtual DbSet<DrugClassification> DrugClassifications { get; set; }
    public virtual DbSet<Manufacturer> Manufacturers { get; set; }
    public virtual DbSet<PrinterSetting> PrinterSettings { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductGenericName> ProductGenericNames { get; set; }
    public virtual DbSet<ProductGroup> ProductGroups { get; set; }
    public virtual DbSet<ProductLocation> ProductLocations { get; set; }
    public virtual DbSet<ProductOrigin> ProductOrigins { get; set; }
    public virtual DbSet<ProductPacking> ProductPackings { get; set; }
    public virtual DbSet<ProductTransfer> ProductTransfers { get; set; }
    public virtual DbSet<ProductUnique> ProductUniques { get; set; }
    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }
    public virtual DbSet<CustomerLoan> CustomerLoans { get; set; }
    public virtual DbSet<Salesman> Salesmen { get; set; }
    public virtual DbSet<SaleOrderItem> SaleOrderItems { get; set; }
    public virtual DbSet<SaleOrder> SaleOrders { get; set; }
    public virtual DbSet<SalesReturn> SalesReturns { get; set; }
    public virtual DbSet<SalesSetting> SalesSettings { get; set; }
    public virtual DbSet<Size> Sizes { get; set; }
    public virtual DbSet<Stock> Stocks { get; set; }
    public virtual DbSet<StockHistory> StockHistories { get; set; }
    public virtual DbSet<Store> Stores { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }
    public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    public virtual DbSet<Area> Areas { get; set; }
    public virtual DbSet<BusinessInformation> BusinessInformations { get; set; }
    public virtual DbSet<CalendarType> CalendarTypes { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<Month> Months { get; set; }
    public virtual DbSet<SaleReturnDetail> SaleReturnDetails { get; set; }
    public virtual DbSet<SaleReturnMain> SaleReturnMains { get; set; }
    public virtual DbSet<SalemanStatementSummary> SalemanStatementSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        => optionsBuilder.UseSqlServer("Password=abc123@;Persist Security Info=True;User ID=sa;Initial Catalog=InventoryBrotherPharmacy;Data Source=.;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        // Convention-based configuration for decimal precision
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }
            
            // Map BaseEntity properties to columns if needed (optional if we dropped legacy columns)
            // But let's assume we want standard names now. 
            // If the DB still has old columns, migrations will handle renaming. 
            // Since User said "new project", we assume we can generate new migration.
        }

        // Configure Aspnet Identity Tables (Legacy) - Minimal config to keep them working if needed
        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).IsClustered(false);
            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
        });
        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId).IsClustered(false);
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });
        modelBuilder.Entity<AspnetPath>(entity =>
        {
            entity.HasKey(e => e.PathId).IsClustered(false);
            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");
        });
        modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        {
            entity.HasKey(e => e.PathId);
            entity.Property(e => e.PathId).ValueGeneratedNever();
        });
        modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });
        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });
        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).IsClustered(false);
            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
        });
        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion });
        });
        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId).IsClustered(false);
            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
        });
        modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        {
            entity.HasKey(e => e.EventId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
