using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Purchases;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Application.DTOs.Catalog;

namespace InventoryBrother.Desktop.ViewModels;

public partial class PurchaseViewModel : ViewModelBase
{
    private readonly IPurchaseService _purchaseService;
    private readonly ICatalogService _catalogService;

    [ObservableProperty]
    private string _invoiceNo = string.Empty;

    [ObservableProperty]
    private string _searchBarCode = string.Empty;

    [ObservableProperty]
    private decimal _amountPaid;

    [ObservableProperty]
    private string _remarks = string.Empty;

    public ObservableCollection<PurchaseItemViewModel> Items { get; } = new();

    public decimal TotalAmount => (decimal)Items.Sum(i => i.Quantity * i.PurchasePrice);

    public PurchaseViewModel(IPurchaseService purchaseService, ICatalogService catalogService)
    {
        _purchaseService = purchaseService;
        _catalogService = catalogService;
    }

    [RelayCommand]
    private async Task AddProductAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchBarCode)) return;

        var products = await _catalogService.SearchProductsAsync(SearchBarCode);
        var product = products.FirstOrDefault();
        if (product != null)
        {
            var existing = Items.FirstOrDefault(i => i.ProductCode == product.ProductCode);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                Items.Add(new PurchaseItemViewModel { 
                    ProductCode = product.ProductCode, 
                    ProductName = product.ProductName,
                    Quantity = 1,
                    PurchasePrice = (double)product.SalePrice,
                    BatchNo = $"B-{DateTime.Now:MMdd}"
                });
            }
            SearchBarCode = string.Empty;
            OnPropertyChanged(nameof(TotalAmount));
        }
    }

    [RelayCommand]
    private void RemoveItem(PurchaseItemViewModel item)
    {
        Items.Remove(item);
        OnPropertyChanged(nameof(TotalAmount));
    }

    [RelayCommand]
    private async Task SubmitPurchaseAsync()
    {
        if (!Items.Any()) return;

        var dto = new CreatePurchaseDto
        {
            SupplierId = 1, // Default for now
            InvoiceNo = InvoiceNo,
            AmountPaid = AmountPaid,
            Remarks = Remarks,
            Items = Items.Select(i => new PurchaseItemDto
            {
                ProductCode = i.ProductCode,
                Quantity = i.Quantity,
                PurchasePrice = i.PurchasePrice,
                BatchNo = i.BatchNo,
                ExpiryDate = i.ExpiryDate
            }).ToList()
        };

        SetBusy("Processing Purchase...");
        var result = await _purchaseService.CreatePurchaseAsync(dto, "Admin", 1);
        ClearBusy();

        if (result.Success)
        {
            Items.Clear();
            InvoiceNo = string.Empty;
            AmountPaid = 0;
            Remarks = string.Empty;
            OnPropertyChanged(nameof(TotalAmount));
        }
        else
        {
            SetError(result.Message ?? "Purchase failed");
        }
    }
}

public partial class PurchaseItemViewModel : ObservableObject
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    private double _quantity;

    [ObservableProperty]
    private double _purchasePrice;

    [ObservableProperty]
    private string _batchNo = string.Empty;

    [ObservableProperty]
    private DateOnly? _expiryDate = DateOnly.FromDateTime(DateTime.Now.AddYears(1));
}
