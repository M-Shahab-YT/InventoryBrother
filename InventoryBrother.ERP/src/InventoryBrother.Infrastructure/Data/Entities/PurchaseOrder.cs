using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblPurchaseOrderMain")]
public partial class PurchaseOrder : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string PurchaseOrderNo { get; set; } = null!;

    public DateOnly? OrderReceivedDate { get; set; }

    public string? SupplierId { get; set; }

    public string? InvoiceNo { get; set; }

    public string? PaymentMethod { get; set; }

    public int? CurrencyId { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? TotalOrderAmount { get; set; }

    public decimal? AmountPaidToSupplier { get; set; }

    public decimal? BalanceAmount { get; set; }

    public string? PaymentStatus { get; set; }



    public string? Remarks { get; set; }
}
