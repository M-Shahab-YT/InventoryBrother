using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblSalesSetting")]
public partial class SalesSetting : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public bool? PrintInvoice { get; set; }

    public string? InvoiceFormat { get; set; }
}
