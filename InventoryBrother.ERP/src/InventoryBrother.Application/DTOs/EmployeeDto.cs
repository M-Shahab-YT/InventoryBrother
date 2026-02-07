using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryBrother.Application.DTOs;

public partial class EmployeeDto : ObservableObject
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _designation;

    [ObservableProperty]
    private int? _departmentId;

    [ObservableProperty]
    private string? _departmentName;

    [ObservableProperty]
    private string? _phone;

    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private decimal? _basicSalary;

    [ObservableProperty]
    private DateTime? _joiningDate;

    [ObservableProperty]
    private bool? _isActive;
}
