using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class Employee : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public int? DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public virtual Department? Department { get; set; }

    [MaxLength(100)]
    public string? Designation { get; set; }

    [MaxLength(50)]
    public string? Phone { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

    public decimal? BasicSalary { get; set; }

    public DateTime? JoiningDate { get; set; }

    public bool IsActive { get; set; } = true;
}
