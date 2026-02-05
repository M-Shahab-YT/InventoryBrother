using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class Stock : BaseEntity
{
    [Key]
    public long Id { get; set; }

    public string ProductCode { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public string BatchNo { get; set; } = null!;

    public double? Quantity { get; set; }

    public double? StockPrice { get; set; }

    // StoreId and Audit fields are in BaseEntity

    public string? Remarks { get; set; }
}
