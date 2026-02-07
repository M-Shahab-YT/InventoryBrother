using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class ProductTransfer : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? TransferNo { get; set; }

    public string? ProductCode { get; set; }

    public double? Quantity { get; set; }

    public int? FromStoreId { get; set; }

    public int? ToStoreId { get; set; }

    public DateTime? TransferDate { get; set; }
}
