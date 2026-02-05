namespace InventoryBrother.Application.DTOs.Reports;

public class InvoiceModel
{
    public string BusinessName { get; set; } = string.Empty;
    public string? StoreName { get; set; }
    public string? Address { get; set; }
    public string? Contact { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string CustomerName { get; set; } = "Walk-in Customer";
    public string CashierName { get; set; } = string.Empty;
    
    public List<InvoiceItemModel> Items { get; set; } = new();
    
    public decimal GrandTotal { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal NetTotal { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal BalanceDue { get; set; }
}

public class InvoiceItemModel
{
    public int SNo { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
}
