using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblRevenue")]
public partial class Revenue : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? RevenueTypeId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public string? Remarks { get; set; }
}
