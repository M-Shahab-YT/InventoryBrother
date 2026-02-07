using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Services;
using InventoryBrother.Desktop.ViewModels;
using InventoryBrother.Desktop.Views;
using InventoryBrother.Desktop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InventoryBrother.Desktop;

public partial class App : Avalonia.Application
{
    public IServiceProvider? Services { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindowModel = Services.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowModel,
            };
            
            // Set initial view to Login
            mainWindowModel.NavigateToLogin();
            
            // Seed Data
            var seeder = Services.GetRequiredService<IDataSeeder>();
            // Fire and forget or wait? For desktop app, better to wait or show splash.
            // For simplicity, we fire and forget but log errors if any (logging not impl).
            _ = Task.Run(async () => await seeder.SeedAsync());
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // 1. Data Access
        var dbConfig = new DatabaseConfiguration
        {
            Mode = DatabaseMode.Online, // Default to online, can be loaded from settings
            SqlServerConnectionString = "Server=.;Database=InventoryBrother;Trusted_Connection=True;TrustServerCertificate=True"
        };
        services.AddSingleton(dbConfig);
        
        services.AddDbContext<InventoryBrotherDbContext>(options => 
            dbConfig.ConfigureDbContext(options));

        // 2. Services
        services.AddSingleton<IAuthService, AuthService>();
        services.AddScoped<ISaleService, SaleService>();
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<IPrintService, PrintService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IFinanceService, FinanceService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPayrollService, PayrollService>();
        services.AddScoped<IDashboardService, DashboardService>(); // Added
        services.AddScoped<IAccountingService, AccountingService>(); // Added
        services.AddSingleton<IDataSeeder, DataSeeder>();
        services.AddSingleton<ILocalizationService, LocalizationService>(); // Added
        services.AddScoped<ILookupService, LookupService>(); // Added
        services.AddSingleton<IExportService, ExportService>();

        // 3. ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<LoginViewModel>(); 
        
        // DashboardViewModel needs MainWindowViewModel, so we use a factory or ensure Singleton resolution works appropriately 
        // if AddTransient is used, it will resolve MainWindowViewModel (Singleton) automatically.
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<LookupViewModel>();
        services.AddTransient<POSViewModel>();
        services.AddTransient<InventoryViewModel>();
        services.AddTransient<PurchaseViewModel>();
        services.AddTransient<FinanceViewModel>();
        services.AddTransient<CustomerViewModel>();
        services.AddTransient<SupplierViewModel>();
        services.AddTransient<EmployeeViewModel>();
        services.AddTransient<AccountingViewModel>();
        services.AddTransient<ChartOfAccountsViewModel>();
        services.AddTransient<JournalEntryViewModel>();
        services.AddTransient<FinancialReportsViewModel>();
        services.AddTransient<AuditLogViewModel>();
    }
}