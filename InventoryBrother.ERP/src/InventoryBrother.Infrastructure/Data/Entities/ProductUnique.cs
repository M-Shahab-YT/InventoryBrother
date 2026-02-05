using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProductUnique")]
public partial class ProductUnique : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? ProductCode { get; set; }

    public string? UniqueNo { get; set; }
}
