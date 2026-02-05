using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Contacts;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class SupplierViewModel : ViewModelBase
{
    private readonly ISupplierService _supplierService;

    [ObservableProperty]
    private string _searchText = string.Empty;

    public ObservableCollection<SupplierDto> Suppliers { get; } = new();

    public SupplierViewModel(ISupplierService supplierService)
    {
        _supplierService = supplierService;
        LoadSuppliersCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadSuppliersAsync()
    {
        SetBusy("Loading Suppliers...");
        try
        {
            var result = await _supplierService.GetAllSuppliersAsync(1); // Default StoreId 1
            Suppliers.Clear();
            foreach (var supplier in result)
            {
                if (string.IsNullOrEmpty(SearchText) || 
                    supplier.SupplierName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    (supplier.ContactMobileNo?.Contains(SearchText) ?? false))
                {
                    Suppliers.Add(supplier);
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
        LoadSuppliersCommand.Execute(null);
    }
}
