using System;
using System.ComponentModel.DataAnnotations;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class SaleReturnMain : BaseEntity
{
    [Key]
    public long Id { get; set; }

    public long? SaleReturnId { get; set; } // Legacy ID or alternative? Keeping as property.

    public long? CustomerId { get; set; }

    public decimal? TotalReturnAmount { get; set; }

    [MaxLength(100)]
    public string? SaleReturnBy { get; set; }

    public DateTime? SaleReturnDate { get; set; }
}
