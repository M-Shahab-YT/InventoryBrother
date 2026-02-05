using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class StockHistory : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? ProductCode { get; set; }

    public double? OpeningQuantity { get; set; }

    public double? ReceivedQuantity { get; set; }

    public double? SoldQuantity { get; set; }

    public double? ClosingQuantity { get; set; }

    public long? StockId { get; set; } // Added for link to Stock

    public DateTime? Date { get; set; }

    // Properties added to support ProductService log usage
    public double? Quantity { get; set; }
    public double? NewQuantity { get; set; }
    public string? Remarks { get; set; }
    public double? AveragePrice { get; set; }
}
