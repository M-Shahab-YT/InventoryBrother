using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblBarcodeLableSetting")]
public partial class BarcodeLabelSetting : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? PaperSize { get; set; }

    public int? LabelHeight { get; set; }

    public int? LabelWidth { get; set; }
}
