using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblChartOfAccount")]
public partial class ChartOfAccount : BaseEntity
{
    [Key]
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountType { get; set; }
}
