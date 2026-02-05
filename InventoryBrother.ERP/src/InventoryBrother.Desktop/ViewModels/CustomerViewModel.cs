using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Contacts;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class CustomerViewModel : ViewModelBase
{
    private readonly ICustomerService _customerService;

    [ObservableProperty]
    private string _searchText = string.Empty;

    public ObservableCollection<CustomerDto> Customers { get; } = new();

    public CustomerViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        LoadCustomersCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadCustomersAsync()
    {
        SetBusy("Loading Customers...");
        try
        {
            var result = await _customerService.GetAllCustomersAsync(1); // Default StoreId 1
            Customers.Clear();
            foreach (var customer in result)
            {
                if (string.IsNullOrEmpty(SearchText) || 
                    customer.CustomerName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    (customer.MobileNumber?.Contains(SearchText) ?? false))
                {
                    Customers.Add(customer);
                }
            }
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private void ClearSearch()
    {
        SearchText = string.Empty;
        LoadCustomersCommand.Execute(null);
    }
}
