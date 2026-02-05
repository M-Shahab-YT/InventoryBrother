using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblPurchaseReturnTransaction")]
public partial class PurchaseReturn : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? ReturnNo { get; set; }

    public string? PurchaseOrderNo { get; set; }

    public string? ProductCode { get; set; }

    public double? Quantity { get; set; }

    public decimal? ReturnPrice { get; set; }

    public DateTime? ReturnDate { get; set; }
}
