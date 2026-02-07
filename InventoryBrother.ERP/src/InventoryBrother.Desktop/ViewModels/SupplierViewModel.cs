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
    private SupplierDto? _selectedSupplier;

    [ObservableProperty]
    private string _searchKey = string.Empty;

    public ObservableCollection<SupplierDto> Suppliers { get; } = new();

    public SupplierViewModel(ISupplierService supplierService)
    {
        _supplierService = supplierService;
        LoadSuppliersCommand.Execute(null);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        await LoadSuppliersAsync();
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
                if (string.IsNullOrWhiteSpace(SearchKey) || 
                    (supplier.SupplierName?.Contains(SearchKey, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (supplier.ContactMobileNo?.Contains(SearchKey) ?? false))
                {
                    Suppliers.Add(supplier);
                }
            }
        }
        catch (Exception ex)
        {
            SetError($"Error loading suppliers: {ex.Message}");
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private void New()
    {
        SelectedSupplier = new SupplierDto();
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (SelectedSupplier == null) return;

        SetBusy("Saving Supplier...");
        try
        {
            if (SelectedSupplier.SupplierId == 0)
            {
                var createDto = new CreateUpdateSupplierDto
                {
                    SupplierName = SelectedSupplier.SupplierName,
                    SupplierAddress = SelectedSupplier.SupplierAddress,
                    ContactPerson = SelectedSupplier.ContactPerson,
                    ContactEmail = SelectedSupplier.ContactEmail,
                    ContactMobileNo = SelectedSupplier.ContactMobileNo,
                    OpeningBalance = SelectedSupplier.OpeningBalance
                };
                await _supplierService.CreateSupplierAsync(createDto, "admin", 1); // Hardcoded for now
            }
            else
            {
                var updateDto = new CreateUpdateSupplierDto
                {
                    SupplierName = SelectedSupplier.SupplierName,
                    SupplierAddress = SelectedSupplier.SupplierAddress,
                    ContactPerson = SelectedSupplier.ContactPerson,
                    ContactEmail = SelectedSupplier.ContactEmail,
                    ContactMobileNo = SelectedSupplier.ContactMobileNo,
                    OpeningBalance = SelectedSupplier.OpeningBalance
                };
                await _supplierService.UpdateSupplierAsync(SelectedSupplier.SupplierId, updateDto, "admin"); // Hardcoded for now
            }
            
            await LoadSuppliersAsync();
            SelectedSupplier = null;
        }
        catch (Exception ex)
        {
            SetError($"Error saving supplier: {ex.Message}");
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedSupplier == null || SelectedSupplier.SupplierId == 0) return;

        SetBusy("Deleting Supplier...");
        try
        {
             // await _supplierService.DeleteSupplierAsync(SelectedSupplier.SupplierId); // Not implemented in interface
             // SelectedSupplier = null;
             // await LoadSuppliersAsync();
             await Task.Delay(100); // Placeholder
             SetError("Delete not implemented in service layer.");
        }
        catch(Exception ex)
        {
             SetError($"Error deleting supplier: {ex.Message}");
        }
        finally
        {
             ClearBusy();
        }
    }

    [RelayCommand]
    private void ClearSearch()
    {
        SearchKey = string.Empty;
        LoadSuppliersCommand.Execute(null);
    }
}
