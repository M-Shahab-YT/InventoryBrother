using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblColor")]
public partial class Color : BaseEntity
{
    [Key]
    public int ColorId { get; set; }

    public string? ColorName { get; set; }
}
