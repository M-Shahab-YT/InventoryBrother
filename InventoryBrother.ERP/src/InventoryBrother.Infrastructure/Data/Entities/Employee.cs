using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("HrmisTblEmployeeInformation")]
public partial class Employee : BaseEntity
{
    [Key]
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Designation { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? JoiningDate { get; set; }
}
