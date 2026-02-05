namespace InventoryBrother.Application.DTOs.Catalog;

public class ProductLookupDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? Barcode { get; set; }
    public string? GenericName { get; set; }
    public decimal SalePrice { get; set; }
}

public class StockLookupDto
{
    public long Id { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string? BatchNo { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal Quantity { get; set; }
    public decimal AveragePrice { get; set; }
}
