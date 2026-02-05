using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("HrmisTblPayrollMonth")]
public partial class PayrollMonth : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? MonthName { get; set; }

    public int? Year { get; set; }
}
