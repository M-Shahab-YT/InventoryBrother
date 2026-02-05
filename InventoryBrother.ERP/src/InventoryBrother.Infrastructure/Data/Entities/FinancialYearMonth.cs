using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblFinancialYearMonth")]
public partial class FinancialYearMonth : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public int? FinancialYearId { get; set; }

    public int? MonthId { get; set; }

    public bool? IsClosed { get; set; }
}
