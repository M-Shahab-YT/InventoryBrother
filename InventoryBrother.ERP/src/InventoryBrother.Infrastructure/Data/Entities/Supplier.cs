using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class Supplier : BaseEntity
{
    [Key]
    public string SupplierId { get; set; } = null!;

    public string? SupplierName { get; set; }

    public string? SupplierMobile { get; set; }

    public string? SupplierAddress { get; set; }

    public string? SupplierEmail { get; set; }

    public string? ContactPerson { get; set; }

    public string? Status { get; set; }

    public decimal? OpeningBalance { get; set; }

    // StoreId and Audit fields are in BaseEntity
}
