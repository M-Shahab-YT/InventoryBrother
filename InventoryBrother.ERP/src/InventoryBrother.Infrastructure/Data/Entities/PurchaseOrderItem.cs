using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class PurchaseOrderItem : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? PurchaseOrderNo { get; set; }

    public string? ProductCode { get; set; }

    public string? BatchNo { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int? CurrencyId { get; set; }

    public double? ExchangeRate { get; set; }

    public decimal? PurchasePrice { get; set; }

    public double? Quantity { get; set; }

    public decimal? Total { get; set; }


}
