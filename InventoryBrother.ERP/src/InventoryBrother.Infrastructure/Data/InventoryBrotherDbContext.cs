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

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditEntries = OnBeforeSaveChanges();
        var result = await base.SaveChangesAsync(cancellationToken);
        await OnAfterSaveChanges(auditEntries);
        return result;
    }

    private List<AuditEntry> OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry(entry);
            auditEntry.TableName = entry.Entity.GetType().Name;
            auditEntries.Add(auditEntry);

            foreach (var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        auditEntry.Action = "Create";
                        break;

                    case EntityState.Deleted:
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.Action = "Delete";
                        break;

                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.Action = "Update";
                        }
                        break;
                }
            }
        }

        foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
        {
            AuditLogs.Add(auditEntry.ToAudit());
        }

        return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
    }

    private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
    {
        if (auditEntries == null || auditEntries.Count == 0)
            return Task.CompletedTask;

        foreach (var auditEntry in auditEntries)
        {
            foreach (var prop in auditEntry.TemporaryProperties)
            {
                if (prop.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                }
                else
                {
                    auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                }
            }
            AuditLogs.Add(auditEntry.ToAudit());
        }

        return SaveChangesAsync();
    }
    
    // START DBSET PROPERTIES
    public virtual DbSet<CashAccount> CashAccounts { get; set; }
    public virtual DbSet<CashAccountTransaction> CashAccountTransactions { get; set; }
    public virtual DbSet<CashierBalance> CashierBalances { get; set; }
    public virtual DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
    public virtual DbSet<CurrencyExchangeRate> CurrencyExchangeRates { get; set; }
    public virtual DbSet<CustomerStatement> CustomerStatements { get; set; }
    public virtual DbSet<EmployeeAdvanceSalary> EmployeeAdvanceSalaries { get; set; }

    public virtual DbSet<JournalEntry> JournalEntries { get; set; }
    public virtual DbSet<JournalEntryLine> JournalEntryLines { get; set; }

    public virtual DbSet<ExpenseDetail> ExpenseDetails { get; set; }
    public virtual DbSet<ExpenseHead> ExpenseHeads { get; set; }
    public virtual DbSet<FinancialYear> FinancialYears { get; set; }
    public virtual DbSet<FinancialYearMonth> FinancialYearMonths { get; set; }
    public virtual DbSet<Payroll> Payrolls { get; set; }
    public virtual DbSet<Revenue> Revenues { get; set; }
    public virtual DbSet<RevenueType> RevenueTypes { get; set; }
    public virtual DbSet<SupplierStatement> SupplierStatements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; } // NEW
    public virtual DbSet<Attendance> Attendances { get; set; } // NEW
    
    public virtual DbSet<PayrollMonth> PayrollMonths { get; set; }
    
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<StockDamage> StockDamages { get; set; }
    
    public virtual DbSet<Manufacturer> Manufacturers { get; set; }
    
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<ProductGroup> ProductGroups { get; set; }
    public virtual DbSet<ProductLocation> ProductLocations { get; set; }
    public virtual DbSet<ProductPacking> ProductPackings { get; set; }
    public virtual DbSet<ProductTransfer> ProductTransfers { get; set; }
    
    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public virtual DbSet<CustomerLoan> CustomerLoans { get; set; }
    
    public virtual DbSet<SaleOrderItem> SaleOrderItems { get; set; }
    public virtual DbSet<SaleOrder> SaleOrders { get; set; }
    
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
            optionsBuilder.UseSqlServer("Password=abc123@;Persist Security Info=True;User ID=sa;Initial Catalog=InventoryBrother;Data Source=.;TrustServerCertificate=True");
        }
    }

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

        // Aspnet Tables removed.

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

internal class AuditEntry
{
    public AuditEntry(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
    {
        Entry = entry;
    }

    public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Entry { get; }
    public string TableName { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public Dictionary<string, object> KeyValues { get; } = new();
    public Dictionary<string, object> OldValues { get; } = new();
    public Dictionary<string, object> NewValues { get; } = new();
    public List<Microsoft.EntityFrameworkCore.ChangeTracking.PropertyEntry> TemporaryProperties { get; } = new();

    public bool HasTemporaryProperties => TemporaryProperties.Any();

    public AuditLog ToAudit()
    {
        var audit = new AuditLog();
        audit.TableName = TableName;
        audit.Action = Action;
        audit.Timestamp = DateTime.Now;
        audit.PrimaryKey = System.Text.Json.JsonSerializer.Serialize(KeyValues);
        audit.OldValues = OldValues.Count == 0 ? null : System.Text.Json.JsonSerializer.Serialize(OldValues);
        audit.NewValues = NewValues.Count == 0 ? null : System.Text.Json.JsonSerializer.Serialize(NewValues);
        return audit;
    }
}
