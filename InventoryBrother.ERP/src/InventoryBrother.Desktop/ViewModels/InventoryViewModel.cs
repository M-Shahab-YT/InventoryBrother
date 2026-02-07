using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Catalog;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class InventoryViewModel : ViewModelBase
{
    private readonly IProductService _productService;
    private readonly IReportService _reportService;
    private readonly IExportService _exportService;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private int? _selectedCategoryId;

    [ObservableProperty]
    private bool _isAddPanelOpen;

    [ObservableProperty]
    private CreateProductDto _newProduct = new();

    private bool _lowStockOnly;

    // Explicit property to ensure access if source generator is lagging
    public bool LowStockOnly
    {
        get => _lowStockOnly;
        set => SetProperty(ref _lowStockOnly, value);
    }

    [RelayCommand]
    private void ToggleAddPanel()
    {
        IsAddPanelOpen = !IsAddPanelOpen;
        if (IsAddPanelOpen)
        {
            NewProduct = new CreateProductDto { 
                ProductCode = "SKU-" + DateTime.Now.Ticks.ToString().Substring(12),
                CategoryId = 1,
                UnitId = 1
            };
        }
    }

    public ObservableCollection<ProductListDto> Products { get; } = new();

    public InventoryViewModel(IProductService productService, IReportService reportService, IExportService exportService)
    {
        _productService = productService;
        _reportService = reportService;
        _exportService = exportService;
        LoadProductsCommand.Execute(null);
    }

    [RelayCommand]
    private async Task PrintStockReportAsync()
    {
        SetBusy("Generating Stock Report...");
        try
        {
            var pdf = await _reportService.GenerateStockReportAsync(1); // Default StoreId 1
            var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"StockReport_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
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

    [RelayCommand]
    private async Task ExportToExcelAsync()
    {
        SetBusy("Exporting to Excel...");
        try
        {
            var data = Products.ToList();
            var bytes = await _exportService.ExportToExcelAsync(data, "Inventory");
            var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"Inventory_{DateTime.Now:yyyyMMdd_HHmm}.csv");
            await System.IO.File.WriteAllBytesAsync(tempPath, bytes);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            SetError("Export failed: " + ex.Message);
        }
        finally
        {
            ClearBusy();
        }
    }

    [RelayCommand]
    private async Task LoadProductsAsync()
    {
        SetBusy("Loading inventory...");
        try
        {
            var filter = new ProductSearchFilter
            {
                SearchTerm = SearchText,
                LowStockOnly = LowStockOnly,
                CategoryId = SelectedCategoryId
            };

            var items = await _productService.GetProductsAsync(filter);
            Products.Clear();
            foreach (var item in items)
            {
                Products.Add(item);
            }
        }
        catch (Exception ex)
        {
            SetError("Failed to load products: " + ex.Message);
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
        LowStockOnly = false;
        LoadProductsCommand.Execute(null);
    }

    [RelayCommand]
    private async Task AddProduct()
    {
        SetBusy("Adding Product...");
        try 
        {
             await _productService.CreateProductAsync(NewProduct);
             IsAddPanelOpen = false;
             await LoadProductsAsync();
        }
        catch(Exception ex)
        {
             SetError($"Failed to create: {ex.Message}");
        }
        finally
        {
             ClearBusy();
        }
    }
}
