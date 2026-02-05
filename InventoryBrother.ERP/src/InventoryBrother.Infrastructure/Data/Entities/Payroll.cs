using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblPayroll")]
public partial class Payroll : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? EmployeeId { get; set; }

    public int? MonthId { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? TotalSalary { get; set; }

    public DateTime? Date { get; set; }
}
