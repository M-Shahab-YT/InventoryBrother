using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class Payroll : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? EmployeeId { get; set; }

    public int? MonthId { get; set; }

    public int? Month { get; set; }
    public int? Year { get; set; }

    public decimal BasicSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Deduction { get; set; }
    public decimal TotalSalary { get; set; } // Net Salary

    public DateTime? Date { get; set; }

    [ForeignKey("EmployeeId")]
    public virtual Employee? Employee { get; set; }
}
