using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProductLocation")]
public partial class ProductLocation : BaseEntity
{
    [Key]
    public int LocationId { get; set; }

    public string? LocationName { get; set; }
}
