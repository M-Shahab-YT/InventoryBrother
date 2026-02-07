using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class PayrollViewModel : ViewModelBase
{
    private readonly IPayrollService _payrollService;

    [ObservableProperty]
    private int _selectedMonth;

    [ObservableProperty]
    private int _selectedYear;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private ObservableCollection<PayrollDto> _payrollList = new();

    public ObservableCollection<int> Months { get; } = new(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
    public ObservableCollection<int> Years { get; } = new();

    public PayrollViewModel(IPayrollService payrollService)
    {
        _payrollService = payrollService;
        
        SelectedMonth = DateTime.Now.Month;
        SelectedYear = DateTime.Now.Year;

        // Populate last 5 years
        for (int i = 0; i < 5; i++)
        {
            Years.Add(DateTime.Now.Year - i);
        }

        // Initial load
        // LoadDataCommand.ExecuteAsync(null); // Optional: don't load immediately or load current month
    }

    [RelayCommand]
    private async Task GeneratePayrollAsync()
    {
        IsBusy = true;
        try
        {
            var result = await _payrollService.GeneratePayrollForMonthAsync(SelectedMonth, SelectedYear);
            PayrollList = new ObservableCollection<PayrollDto>(result);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task LoadPayrollAsync()
    {
        IsBusy = true;
        try
        {
            var result = await _payrollService.GetPayrollHistoryAsync(SelectedMonth, SelectedYear);
            PayrollList = new ObservableCollection<PayrollDto>(result);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
