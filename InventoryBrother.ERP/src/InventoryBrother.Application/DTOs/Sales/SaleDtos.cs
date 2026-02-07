namespace InventoryBrother.Application.DTOs.Sales;

public class CreateSaleDto
{
    public string? CustomerId { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public int CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; }
    public string? Remarks { get; set; }
    public int? SaleManId { get; set; }
    public List<SaleItemDto> Items { get; set; } = new();
    
    // Payment info
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public int? PaymentAccountId { get; set; }
}

public class SaleItemDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string? BatchNo { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public long ProductStockId { get; set; }
    public decimal Quantity { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Discount { get; set; }
    public decimal AveragePrice { get; set; } // For profit calculation
}

public class SaleResponseDto
{
    public string InvoiceNo { get; set; } = string.Empty;
    public bool Success { get; set; }
    public string? Message { get; set; }
}

public class SaleListDto
{
    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string? CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
}
