using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblDamageOrLost")]
public partial class StockDamage : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? ProductCode { get; set; }

    public double? Quantity { get; set; }

    public string? Reason { get; set; }


}
