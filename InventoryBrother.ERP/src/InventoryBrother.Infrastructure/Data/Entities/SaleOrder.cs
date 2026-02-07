using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class SaleOrder : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public DateOnly? SaleOrderDate { get; set; }

    public TimeOnly? SaleOrderTime { get; set; }

    public string? CustomerId { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? TotalOrderAmount { get; set; }

    public decimal? TotalPaidAmount { get; set; }

    public decimal? BalanceAmount { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? TotalBaseCurrencyAmount { get; set; }

    public decimal? TotalBaseCurrencyPaidAmount { get; set; }

    public decimal? TotalBaseCurrencyBalanceAmount { get; set; }

    public string? Remarks { get; set; }

    public string? Status { get; set; }

    // StoreId and Audit fields are in BaseEntity

    public decimal? CashReturnToCustomer { get; set; }

    public decimal? BaseCurrencyCashReturnToCustomer { get; set; }
}
