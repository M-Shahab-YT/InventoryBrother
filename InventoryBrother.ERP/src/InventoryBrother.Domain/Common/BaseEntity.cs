using System;

namespace InventoryBrother.Domain.Common;

public abstract class BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Multi-branch support
    public int StoreId { get; set; } = 1;
}
