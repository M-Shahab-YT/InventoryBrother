using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InventoryBrother.Desktop.ViewModels;

/// <summary>
/// Main window ViewModel - serves as the application shell
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _currentView;
    
    [ObservableProperty]
    private string _title = "InventoryBrother ERP";
    
    [ObservableProperty]
    private string _userName = string.Empty;
    
    [ObservableProperty]
    private string _storeName = string.Empty;
    
    [ObservableProperty]
    private bool _isOfflineMode;
    
    [ObservableProperty]
    private bool _isLoggedIn;
    
    private readonly IServiceProvider _serviceProvider;

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        Title = "InventoryBrother ERP";
    }
    
    [RelayCommand]
    private void NavigateToStock()
    {
        var invViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(InventoryViewModel))!;
        CurrentView = invViewModel;
        Title = "Inventory Management - InventoryBrother";
    }
    
    [RelayCommand]
    private void NavigateToSales()
    {
        var posViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(POSViewModel))!;
        CurrentView = posViewModel;
        Title = "Point of Sale - InventoryBrother";
    }
    
    [RelayCommand]
    private void NavigateToPurchase()
    {
        var purchaseViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(PurchaseViewModel))!;
        CurrentView = purchaseViewModel;
        Title = "Procurement & Purchases - InventoryBrother";
    }
    
    [RelayCommand]
    private void NavigateToReports()
    {
        var financeViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(FinanceViewModel))!;
        CurrentView = financeViewModel;
        Title = "Financial Ledger & Statements - InventoryBrother";
    }

    [RelayCommand]
    private void NavigateToCustomers()
    {
        var customerViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(CustomerViewModel))!;
        CurrentView = customerViewModel;
        Title = "Customer Directory - InventoryBrother";
    }
    
    [RelayCommand]
    private void NavigateToSuppliers()
    {
        var supplierViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(SupplierViewModel))!;
        CurrentView = supplierViewModel;
        Title = "Supplier Directory - InventoryBrother";
    }
    
    [RelayCommand]
    private void Logout()
    {
        IsLoggedIn = false;
        UserName = string.Empty;
        // TODO: Navigate to Login view
    }
}
