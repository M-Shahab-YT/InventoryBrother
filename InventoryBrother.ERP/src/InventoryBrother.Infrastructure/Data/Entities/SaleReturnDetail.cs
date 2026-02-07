using System;
using System.ComponentModel.DataAnnotations;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class SaleReturnDetail : BaseEntity
{
    [Key]
    public long Id { get; set; }

    public long? SaleReturnId { get; set; }

    [MaxLength(50)]
    public string? InvoiceNo { get; set; }

    public int? RowNumber { get; set; }

    [MaxLength(50)]
    public string? ProductCode { get; set; }

    public int? ReturnQuantity { get; set; }

    public decimal? ReturnAmount { get; set; }

    public int? SalesmainId { get; set; }

    public DateTime? ReturnDate { get; set; }

    [MaxLength(50)]
    public string? ReturnUserId { get; set; }

    [MaxLength(100)]
    public string? CalculatedToSalesMan { get; set; }

    public int? ProductStockId { get; set; }

    public decimal? Rate { get; set; }
}
