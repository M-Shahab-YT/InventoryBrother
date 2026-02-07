using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryBrother.Desktop.ViewModels;

public partial class AccountingViewModel : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ViewModelBase _currentTab;

    public AccountingViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        // Default to Chart of Accounts
        CurrentTab = _serviceProvider.GetRequiredService<ChartOfAccountsViewModel>();
    }

    [RelayCommand]
    private void ShowChartOfAccounts()
    {
        CurrentTab = _serviceProvider.GetRequiredService<ChartOfAccountsViewModel>();
    }

    [RelayCommand]
    private void ShowJournalEntry()
    {
        CurrentTab = _serviceProvider.GetRequiredService<JournalEntryViewModel>();
    }

    [RelayCommand]
    private void ShowReports()
    {
        CurrentTab = _serviceProvider.GetRequiredService<FinancialReportsViewModel>();
    }
}
