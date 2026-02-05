using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Sales;
using InventoryBrother.Application.DTOs.Catalog;
using InventoryBrother.Application.Interfaces;

namespace InventoryBrother.Desktop.ViewModels;

public partial class POSViewModel : ViewModelBase
{
    private readonly ISaleService _saleService;
    private readonly ICatalogService _catalogService;
    private readonly IPrintService _printService;

    [ObservableProperty]
    private string _searchBarCode = string.Empty;

    [ObservableProperty]
    private decimal _grandTotal;

    [ObservableProperty]
    private decimal _totalDiscount;

    [ObservableProperty]
    private decimal _netTotal;

    [ObservableProperty]
    private decimal _paidAmount;

    [ObservableProperty]
    private decimal _changeAmount;

    public ObservableCollection<CartItemViewModel> CartItems { get; } = new();

    public POSViewModel(ISaleService saleService, ICatalogService catalogService, IPrintService printService)
    {
        _saleService = saleService;
        _catalogService = catalogService;
        _printService = printService;
    }

    [RelayCommand]
    private async Task AddItemAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchBarCode)) return;

        var products = await _catalogService.SearchProductsAsync(SearchBarCode);
        var product = products.FirstOrDefault();

        if (product != null)
        {
            var stocks = await _catalogService.GetStockForProductAsync(product.ProductCode);
            var stock = stocks.FirstOrDefault();

            if (stock != null)
            {
                var existing = CartItems.FirstOrDefault(i => i.ProductCode == product.ProductCode);
                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    CartItems.Add(new CartItemViewModel
                    {
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        Price = product.SalePrice > 0 ? product.SalePrice : 100, // Fallback
                        ProductStockId = stock.Id,
                        AveragePrice = stock.AveragePrice
                    });
                }
                UpdateTotals();
            }
        }
        SearchBarCode = string.Empty;
    }

    private void UpdateTotals()
    {
        GrandTotal = CartItems.Sum(i => i.Total);
        TotalDiscount = CartItems.Sum(i => i.Discount);
        NetTotal = GrandTotal - TotalDiscount;
        UpdateChange();
    }

    partial void OnPaidAmountChanged(decimal value) => UpdateChange();

    private void UpdateChange()
    {
        ChangeAmount = Math.Max(0, PaidAmount - NetTotal);
    }

    [RelayCommand]
    private async Task ProcessSaleAsync()
    {
        if (!CartItems.Any()) return;

        SetBusy("Processing Sale...");
        
        var dto = new CreateSaleDto
        {
            TotalAmount = NetTotal,
            PaidAmount = PaidAmount,
            CurrencyId = 1, // Default
            ExchangeRate = 1,
            Items = CartItems.Select(i => new SaleItemDto
            {
                ProductCode = i.ProductCode,
                Quantity = i.Quantity,
                SalePrice = i.Price,
                Discount = i.Discount,
                ProductStockId = i.ProductStockId,
                AveragePrice = i.AveragePrice
            }).ToList()
        };

        var result = await _saleService.CreateSaleAsync(dto);
        ClearBusy();

        if (result.Success)
        {
            CartItems.Clear();
            PaidAmount = 0;
            UpdateTotals();
            await PrintInvoiceAsync(result.InvoiceNo);
        }
        else
        {
            SetError(result.Message ?? "Sale failed");
        }
    }

    [RelayCommand]
    public async Task PrintInvoiceAsync(string invoiceNo)
    {
        SetBusy("Generating Invoice PDF...");
        try
        {
            var model = await _saleService.GetInvoiceDetailsAsync(invoiceNo);
            if (model != null)
            {
                var pdf = _printService.GenerateInvoicePdf(model);
                
                // Save to temp file and open
                var tempPath = Path.Combine(Path.GetTempPath(), $"Invoice_{invoiceNo}.pdf");
                await File.WriteAllBytesAsync(tempPath, pdf);
                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
        }
        catch (Exception ex)
        {
            SetError("Failed to print: " + ex.Message);
        }
        finally
        {
            ClearBusy();
        }
    }
}

public partial class CartItemViewModel : ObservableObject
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    private decimal _quantity;

    [ObservableProperty]
    private decimal _price;

    [ObservableProperty]
    private decimal _discount;

    public decimal Total => Quantity * Price;
    
    public long ProductStockId { get; set; }
    public decimal AveragePrice { get; set; }
    
    partial void OnQuantityChanged(decimal value) => OnPropertyChanged(nameof(Total));
    partial void OnPriceChanged(decimal value) => OnPropertyChanged(nameof(Total));
}
