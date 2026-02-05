using System;
using System.Collections.Generic;

namespace InventoryBrother.Application.DTOs.Reports;

public class StockReportModel
{
    public string BusinessName { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public List<StockReportItem> Items { get; set; } = new();
    public decimal TotalValuationCost { get; set; }
    public decimal TotalValuationSale { get; set; }
}

public class StockReportItem
{
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string? BatchNo { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal StockValueCost => Quantity * CostPrice;
    public decimal StockValueSale => Quantity * SalePrice;
}

public class SalesSummaryReportModel
{
    public string BusinessName { get; set; } = string.Empty;
    public string StoreName { get; set; } = string.Empty;
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public List<SalesSummaryItem> Items { get; set; } = new();
    public decimal TotalSales { get; set; }
    public decimal TotalProfit { get; set; }
}

public class SalesSummaryItem
{
    public DateTime Date { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal Profit { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
}
