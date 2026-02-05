using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblSalesReturnTransaction")]
public partial class SalesReturn : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? SalesReturnNo { get; set; }

    public string? SaleOrderNo { get; set; }

    public string? ProductCode { get; set; }

    public double? Quantity { get; set; }

    public decimal? ReturnPrice { get; set; }

    public DateTime? ReturnDate { get; set; }
}
