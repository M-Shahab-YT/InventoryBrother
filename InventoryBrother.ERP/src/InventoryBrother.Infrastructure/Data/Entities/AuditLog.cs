using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryBrother.Infrastructure.Data.Entities;

public class AuditLog
{
    [Key]
    public long Id { get; set; }

    public string? UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string TableName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Action { get; set; } = string.Empty; // Create, Update, Delete

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    [Required]
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public string? AffectedColumns { get; set; }

    public string? PrimaryKey { get; set; }
}
