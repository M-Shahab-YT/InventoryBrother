using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Accounting;
using InventoryBrother.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBrother.Desktop.ViewModels;

public partial class FinancialReportsViewModel : ViewModelBase
{
    private readonly IAccountingService _accountingService;
    private readonly IExportService _exportService;

    [ObservableProperty]
    private TrialBalanceDto? _trialBalance;

    [ObservableProperty]
    private ProfitLossDto? _profitLoss;

    [ObservableProperty]
    private bool _showTrialBalance = true;

    [ObservableProperty]
    private DateTime _fromDate = DateTime.Now.AddMonths(-1);

    [ObservableProperty]
    private DateTime _toDate = DateTime.Now;

    public FinancialReportsViewModel(IAccountingService accountingService, IExportService exportService)
    {
        _accountingService = accountingService;
        _exportService = exportService;
    }

    [RelayCommand]
    private async Task GenerateTrialBalance()
    {
        ShowTrialBalance = true;
        TrialBalance = await _accountingService.GetTrialBalanceAsync();
        ProfitLoss = null;
    }

    [RelayCommand]
    private async Task ExportToExcelAsync()
    {
        if (ShowTrialBalance && TrialBalance != null)
        {
            SetBusy("Exporting Trial Balance...");
            try
            {
                var bytes = await _exportService.ExportToExcelAsync(TrialBalance.Lines, "TrialBalance");
                var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"TrialBalance_{DateTime.Now:yyyyMMdd_HHmm}.csv");
                await System.IO.File.WriteAllBytesAsync(tempPath, bytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            finally { ClearBusy(); }
        }
        else if (!ShowTrialBalance && ProfitLoss != null)
        {
            // P&L is more complex to export to a simple table, but we can export the details.
            SetBusy("Exporting P&L Details...");
            try
            {
                var allDetails = ProfitLoss.IncomeDetails.Concat(ProfitLoss.ExpenseDetails).ToList();
                var bytes = await _exportService.ExportToExcelAsync(allDetails, "ProfitLoss");
                var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"ProfitLoss_{DateTime.Now:yyyyMMdd_HHmm}.csv");
                await System.IO.File.WriteAllBytesAsync(tempPath, bytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            finally { ClearBusy(); }
        }
    }

    [RelayCommand]
    private async Task GenerateProfitLoss()
    {
        ShowTrialBalance = false;
        ProfitLoss = await _accountingService.GetProfitLossAsync(FromDate, ToDate);
        TrialBalance = null;
    }
}
