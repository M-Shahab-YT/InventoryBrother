using System;
using System.Collections.Generic;

namespace InventoryBrother.Application.DTOs.Purchases;

public class CreatePurchaseDto
{
    public int SupplierId { get; set; }
    public string? InvoiceNo { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public int CurrencyId { get; set; } = 1;
    public decimal ExchangeRate { get; set; } = 1;
    public decimal AmountPaid { get; set; }
    public string? Remarks { get; set; }
    public List<PurchaseItemDto> Items { get; set; } = new();
}

public class PurchaseItemDto
{
    public string ProductCode { get; set; } = string.Empty;
    public string BatchNo { get; set; } = string.Empty;
    public DateOnly? ExpiryDate { get; set; }
    public double Quantity { get; set; }
    public double PurchasePrice { get; set; }
}

public class PurchaseResponseDto
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? PurchaseOrderNo { get; set; }
}
