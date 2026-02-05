using System;
using System.Collections.Generic;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class SaleReturnMain
{
    public long? SaleReturnId { get; set; }

    public long? CustomerId { get; set; }

    public decimal? TotalReturnAmount { get; set; }

    public string? SaleReturnBy { get; set; }

    public DateTime? SaleReturnDate { get; set; }
}
