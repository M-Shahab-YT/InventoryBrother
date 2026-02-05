using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblCashierBalance")]
public partial class CashierBalance : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? CashierId { get; set; }

    public decimal? OpeningBalance { get; set; }

    public decimal? ClosingBalance { get; set; }

    public DateTime? Date { get; set; }
}
