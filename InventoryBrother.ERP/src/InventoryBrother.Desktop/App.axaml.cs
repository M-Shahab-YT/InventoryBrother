using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Services;
using InventoryBrother.Desktop.ViewModels;
using InventoryBrother.Desktop.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            
            // Set initial view
            mainWindowModel.CurrentView = Services.GetRequiredService<POSViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // 1. Data Access
        var dbConfig = new DatabaseConfiguration
        {
            Mode = DatabaseMode.Online, // Default to online, can be loaded from settings
            SqlServerConnectionString = "Server=.;Database=InventoryBrotherPharmacy;Trusted_Connection=True;TrustServerCertificate=True"
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

        // 3. ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<POSViewModel>();
        services.AddTransient<InventoryViewModel>();
        services.AddTransient<PurchaseViewModel>();
        services.AddTransient<FinanceViewModel>();
        services.AddTransient<CustomerViewModel>();
        services.AddTransient<SupplierViewModel>();
    }
}