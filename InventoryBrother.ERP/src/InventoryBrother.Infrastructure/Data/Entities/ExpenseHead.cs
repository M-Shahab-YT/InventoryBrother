using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblExpenseHead")]
public partial class ExpenseHead : BaseEntity
{
    [Key]
    public int ExpenseHeadId { get; set; }

    public string? ExpenseHeadName { get; set; }
}
