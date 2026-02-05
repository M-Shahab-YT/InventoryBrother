using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblPrinterSetting")]
public partial class PrinterSetting : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? PrinterName { get; set; }

    public string? PrinterType { get; set; }
}
