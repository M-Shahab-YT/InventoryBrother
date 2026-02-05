using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProduct")]
public partial class Product : BaseEntity
{
    [Key]
    public string ProductCode { get; set; } = null!;

    public string? ProductName { get; set; }

    public int? ProductGenericNameId { get; set; }

    public string? ProductGenericName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductBarCodeType { get; set; }

    public string? ProductBarCode { get; set; }

    public string? BarcodeLabelValue { get; set; }

    public int? ProductCategoryId { get; set; }

    public string? ProductManufacturerId { get; set; }

    public int? ProductOriginId { get; set; }

    public string? ProductClassificationId { get; set; }

    public int? UnitId { get; set; }

    public int? PackingId { get; set; }

    public int? SizeId { get; set; }

    public int? ColorId { get; set; }

    public int? ProductLocationId { get; set; }

    public double? SalePrice { get; set; }

    public double? Mrp { get; set; }

    public double? Discount { get; set; }

    public double? QuantityAtScan { get; set; }

    // Audit fields are now in BaseEntity
    // We can map them in OnModelCreating if names differ in DB

    public string? BarCodePrice { get; set; }

    public double? MinimumStockQty { get; set; }

    public double? DiscountParentage { get; set; }
}
