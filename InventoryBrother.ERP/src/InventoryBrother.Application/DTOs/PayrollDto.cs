using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryBrother.Application.DTOs;

public partial class PayrollDto : ObservableObject
{
    [ObservableProperty]
    private long _id;

    [ObservableProperty]
    private int _employeeId;

    [ObservableProperty]
    private string? _employeeName;
    
    [ObservableProperty]
    private string? _designation;

    [ObservableProperty]
    private int _month;

    [ObservableProperty]
    private int _year;

    [ObservableProperty]
    private decimal? _basicSalary;
    
    [ObservableProperty]
    private decimal? _allowance;

    [ObservableProperty]
    private decimal? _deduction;

    [ObservableProperty]
    private decimal? _netSalary;
    
    [ObservableProperty]
    private DateTime? _paymentDate;

    [ObservableProperty]
    private string? _status; // "Pending", "Paid"
}
