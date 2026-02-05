using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblAveragePrice")]
public partial class AveragePrice : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? ProductCode { get; set; }

    public decimal? AvgPrice { get; set; }

    public decimal? LastPurchasePrice { get; set; }
}
