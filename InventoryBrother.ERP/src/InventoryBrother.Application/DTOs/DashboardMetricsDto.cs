namespace InventoryBrother.Application.DTOs;

public class DashboardMetricsDto
{
    public decimal TotalSalesToday { get; set; }
    public decimal TotalSalesMonth { get; set; }
    public decimal TotalPurchasesMonth { get; set; }
    
    public int LowStockItemsCount { get; set; }
    
    public decimal CustomerDueAmount { get; set; }
    public decimal SupplierPayableAmount { get; set; }
    
    public decimal CashInHand { get; set; }
    
    public List<TopProductDto> TopProducts { get; set; } = new();
    public List<MonthlyTrendDto> SalesTrend { get; set; } = new();
}

public class TopProductDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal TotalQty { get; set; }
}

public class MonthlyTrendDto
{
    public string MonthName { get; set; } = string.Empty;
    public decimal SalesAmount { get; set; }
}
