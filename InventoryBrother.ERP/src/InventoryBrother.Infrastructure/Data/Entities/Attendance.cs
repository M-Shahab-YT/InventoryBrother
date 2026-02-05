using System;
using System.ComponentModel.DataAnnotations;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public class Attendance : BaseEntity
{
    [Key]
    public long Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly? CheckInTime { get; set; }

    public TimeOnly? CheckOutTime { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "Present"; // Present, Absent, Leave, Late

    [MaxLength(500)]
    public string? Remarks { get; set; }
}
