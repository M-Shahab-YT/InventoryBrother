using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblExpenseDetail")]
public partial class ExpenseDetail : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? ExpenseHeadId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public string? Remarks { get; set; }
}
