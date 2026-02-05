namespace InventoryBrother.Application.DTOs.Catalog;

public class ProductListDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? ProductBarCode { get; set; }
    public decimal SalePrice { get; set; }
    public decimal CurrentStock { get; set; }
    public decimal MinimumStockQty { get; set; }
    public string? CategoryName { get; set; }
}

public class ProductDetailDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductBarCode { get; set; }
    public int? ProductCategoryId { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Mrp { get; set; }
    public decimal Discount { get; set; }
    public decimal MinimumStockQty { get; set; }
}

public class StockAdjustmentDto
{
    public long StockId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public decimal NewQuantity { get; set; }
    public string? Remarks { get; set; }
}

public class ProductSearchFilter
{
    public string? SearchTerm { get; set; }
    public int? CategoryId { get; set; }
    public bool LowStockOnly { get; set; }
}
