using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class SaleOrderItem : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string? ProductCode { get; set; }

    public string? BatchNo { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? ProductStockId { get; set; }

    public double? Quantity { get; set; }

    public double? BaseCurrencyAveragePrice { get; set; }

    public double? SalePrice { get; set; }

    public double? Discount { get; set; }

    public int? CurrencyId { get; set; }

    public double? ExchangeRate { get; set; }

    public double? BaseCurrencySalePrice { get; set; }

    public double? BaseCurrencyDiscount { get; set; }

    public double? BaseCurrencyProfitPerUnit { get; set; }

    public double? TotalBaseCurrencyProfit { get; set; }

    public double? Total { get; set; }

    public double? BaseCurrencyTotal { get; set; }

    public string? Status { get; set; }

    public string? SalesManId { get; set; }



    public string? Remarks { get; set; }
}
