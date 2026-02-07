using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Media;
using InventoryBrother.Application.Interfaces;

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
    private readonly ILocalizationService _localizationService;
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _userRole = string.Empty;

    public bool IsAdmin => UserRole == "Admin";
    public bool IsManager => UserRole == "Manager" || UserRole == "Admin";

    public FlowDirection CurrentFlowDirection => _localizationService.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

    public MainWindowViewModel(IServiceProvider serviceProvider, ILocalizationService localizationService, IAuthService authService)
    {
        _serviceProvider = serviceProvider;
        _localizationService = localizationService;
        _authService = authService;
        
        // Update FlowDirection when language changes
        _localizationService.PropertyChanged += (s, e) => {
            if (e.PropertyName == nameof(ILocalizationService.IsRightToLeft))
            {
                OnPropertyChanged(nameof(CurrentFlowDirection));
            }
        };

        Title = "Dashboard - InventoryBrother ERP";
        // Default to Dashboard
        // NavigateToDashboard(); // Removed to avoid circular dependency at startup
    }

    public bool IsPashto => _localizationService.CurrentLanguage == "ps";

    [RelayCommand]
    private void SetLanguage(string lang)
    {
        _localizationService.SetLanguage(lang == "en" ? "ps" : "en"); // Toggle for simplicity or use parameter
        OnPropertyChanged(nameof(IsPashto));
    }

    [RelayCommand]
    private void NavigateToDashboard()
    {
        var dashboardViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(DashboardViewModel))!;
        CurrentView = dashboardViewModel;
        Title = "Dashboard - InventoryBrother ERP";
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
    private void NavigateToEmployees()
    {
        var employeeViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(EmployeeViewModel))!;
        CurrentView = employeeViewModel;
        Title = "HR & Employee Management - InventoryBrother";
    }

    [RelayCommand]
    private void NavigateToPayroll()
    {
        var payrollViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(PayrollViewModel))!;
        CurrentView = payrollViewModel;
        Title = "Payroll & Salary Processing - InventoryBrother";
    }

    [RelayCommand]
    private void NavigateToAccounting()
    {
        var accountingViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(AccountingViewModel))!;
        CurrentView = accountingViewModel;
        Title = "Advanced Accounting - InventoryBrother";
    }

    [RelayCommand]
    private void NavigateToLookups()
    {
        var lookupViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(LookupViewModel))!;
        CurrentView = lookupViewModel;
        Title = "Settings & Lookups - InventoryBrother";
    }

    [RelayCommand]
    private void NavigateToAuditLogs()
    {
        var auditViewModel = (ViewModelBase)_serviceProvider.GetService(typeof(AuditLogViewModel))!;
        CurrentView = auditViewModel;
        Title = "Audit Trail & System Logs - InventoryBrother";
    }
    
    public void OnLoginSuccess()
    {
        IsLoggedIn = true;
        UserName = _authService.CurrentUserName ?? "User";
        UserRole = _authService.CurrentUserRole ?? "User";
        
        OnPropertyChanged(nameof(IsAdmin));
        OnPropertyChanged(nameof(IsManager));
        
        NavigateToDashboard();
    }

    [RelayCommand]
    private void Logout()
    {
        _authService.LogoutAsync();
        IsLoggedIn = false;
        UserName = string.Empty;
        UserRole = string.Empty;
        
        OnPropertyChanged(nameof(IsAdmin));
        OnPropertyChanged(nameof(IsManager));
        
        NavigateToLogin();
    }

    public void NavigateToLogin()
    {
        CurrentView = (ViewModelBase)_serviceProvider.GetService(typeof(LoginViewModel))!;
        Title = "Login - InventoryBrother ERP";
    }
}
