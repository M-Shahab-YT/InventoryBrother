using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs;
using InventoryBrother.Application.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace InventoryBrother.Desktop.ViewModels;

public partial class EmployeeViewModel : ViewModelBase
{
    private readonly IEmployeeService _employeeService;

    [ObservableProperty]
    private ObservableCollection<EmployeeDto> _employees = new();

    [ObservableProperty]
    private EmployeeDto _selectedEmployee;

    [ObservableProperty]
    private ObservableCollection<DepartmentDto> _departments = new();

    [ObservableProperty]
    private bool _isBusy;

    public EmployeeViewModel(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        _selectedEmployee = new EmployeeDto(); // Start with a blank employee
        LoadDataCommand.ExecuteAsync(null);
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        IsBusy = true;
        try
        {
            var emps = await _employeeService.GetAllEmployeesAsync();
            Employees = new ObservableCollection<EmployeeDto>(emps);

            var deps = await _employeeService.GetAllDepartmentsAsync();
            Departments = new ObservableCollection<DepartmentDto>(deps);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (SelectedEmployee == null) return;

        IsBusy = true;
        try
        {
            if (SelectedEmployee.Id == 0)
            {
                var newEmp = await _employeeService.CreateEmployeeAsync(SelectedEmployee);
                Employees.Add(newEmp);
            }
            else
            {
                await _employeeService.UpdateEmployeeAsync(SelectedEmployee);
                // Refresh list or update item in place
                var index = Employees.IndexOf(Employees.FirstOrDefault(e => e.Id == SelectedEmployee.Id));
                if (index >= 0)
                {
                    Employees[index] = SelectedEmployee;
                }
            }
            
            // Reset selection or notify success
            SelectedEmployee = new EmployeeDto(); 
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedEmployee == null || SelectedEmployee.Id == 0) return;

        IsBusy = true;
        try
        {
            await _employeeService.DeleteEmployeeAsync(SelectedEmployee.Id);
            Employees.Remove(SelectedEmployee);
            SelectedEmployee = new EmployeeDto();
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void New()
    {
        SelectedEmployee = new EmployeeDto
        {
            IsActive = true,
            JoiningDate = DateTime.Now
        };
    }

    partial void OnSelectedEmployeeChanged(EmployeeDto value)
    {
        // When selection changes, ensure we're editing a copy if we want cancel support,
        // but for simplicity here we bind directly.
        // If value is null (e.g. during list clear), recreate empty
        if (value == null)
        {
             // Careful with loops?
        }
    }
}
