using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Finance;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class FinanceViewModel : ViewModelBase
{
    private readonly IFinanceService _financeService;
    private readonly IReportService _reportService;

    [ObservableProperty]
    private int _selectedCustomerId = 1;

    [ObservableProperty]
    private int _selectedSupplierId = 1;

    public ObservableCollection<CashAccountDto> CashAccounts { get; } = new();
    public ObservableCollection<TransactionDto> Statement { get; } = new();

    public FinanceViewModel(IFinanceService financeService, IReportService reportService)
    {
        _financeService = financeService;
        _reportService = reportService;
        LoadDashboardCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadDashboardAsync()
    {
        SetBusy("Loading Finance Dashboard...");
        try
        {
            var accounts = await _financeService.GetCashAccountsAsync(1);
            CashAccounts.Clear();
            foreach (var acc in accounts)
            {
                CashAccounts.Add(acc);
            }
        }
        catch (Exception ex)
        {
            SetError("Failed to load: " + ex.Message);
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private async Task LoadCustomerStatementAsync()
    {
        SetBusy("Fetching Customer Statement...");
        try
        {
            var trans = await _financeService.GetCustomerStatementAsync(SelectedCustomerId, DateTime.Now.AddMonths(-3), DateTime.Now);
            Statement.Clear();
            foreach (var t in trans)
            {
                Statement.Add(t);
            }
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private async Task LoadSupplierStatementAsync()
    {
        SetBusy("Fetching Supplier Statement...");
        try
        {
            var trans = await _financeService.GetSupplierStatementAsync(SelectedSupplierId, DateTime.Now.AddMonths(-3), DateTime.Now);
            Statement.Clear();
            foreach (var t in trans)
            {
                Statement.Add(t);
            }
        }
        finally
        {
            ClearBusy();
        }
    }
    [RelayCommand]
    private async Task PrintSalesReportAsync()
    {
        SetBusy("Generating Sales Report...");
        try
        {
            var pdf = await _reportService.GenerateSalesSummaryReportAsync(DateTime.Now.AddDays(-30), DateTime.Now, 1);
            var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"SalesReport_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            await System.IO.File.WriteAllBytesAsync(tempPath, pdf);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            SetError("Failed to generate report: " + ex.Message);
        }
        finally
        {
            ClearBusy();
        }
    }
}
