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

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private bool _lowStockOnly;

    public ObservableCollection<ProductListDto> Products { get; } = new();

    public InventoryViewModel(IProductService productService, IReportService reportService)
    {
        _productService = productService;
        _reportService = reportService;
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
    private async Task LoadProductsAsync()
    {
        SetBusy("Loading inventory...");
        try
        {
            var filter = new ProductSearchFilter
            {
                SearchTerm = SearchText,
                LowStockOnly = LowStockOnly
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
}
