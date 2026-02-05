using System;
using System.Collections.Generic;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class SaleReturnDetail
{
    public long? SaleReturnId { get; set; }

    public long Id { get; set; }

    public string? InvoiceNo { get; set; }

    public int? RowNumber { get; set; }

    public string? ProductCode { get; set; }

    public int? ReturnQuantity { get; set; }

    public double? ReturnAmount { get; set; }

    public int? SalesmainId { get; set; }

    public int? StoreId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? ReturnUserId { get; set; }

    public string? CalculatedToSalesMan { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? ProductStockId { get; set; }

    public double? Rate { get; set; }
}
