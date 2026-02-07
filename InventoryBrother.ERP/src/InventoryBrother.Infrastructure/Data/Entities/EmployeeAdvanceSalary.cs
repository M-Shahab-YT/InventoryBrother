using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class EmployeeAdvanceSalary : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? AdvanceAmount { get; set; }

    public DateTime? Date { get; set; }
}
