using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblRevenueSetting")]
public partial class RevenueSetting : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public bool? IsActive { get; set; }
}
