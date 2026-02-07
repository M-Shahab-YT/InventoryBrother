using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly IDashboardService _dashboardService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private DashboardMetricsDto _metrics = new();

    [ObservableProperty]
    private bool _isLoading;

    public DashboardViewModel(IDashboardService dashboardService, IServiceProvider serviceProvider)
    {
        _dashboardService = dashboardService;
        _serviceProvider = serviceProvider;
        Initialize();
    }

    private async void Initialize()
    {
        await LoadMetricsAsync();
    }

    [RelayCommand]
    private async Task LoadMetricsAsync()
    {
        IsLoading = true;
        try
        {
            Metrics = await _dashboardService.GetKeyMetricsAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void NavigateToSale()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        mainViewModel.NavigateToSalesCommand.Execute(null);
    }

    [RelayCommand]
    private void NavigateToProduct()
    {
         // Assuming we want to go into "Add Product" mode directly, 
         // but for now let's navigate to Inventory and maybe trigger add?
         // Simpler: Just go to Inventory for now, or trigger a specific action.
        var mainViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        mainViewModel.NavigateToStockCommand.Execute(null);
    }
}
