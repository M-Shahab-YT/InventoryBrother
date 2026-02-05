using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProductOrigin")]
public partial class ProductOrigin : BaseEntity
{
    [Key]
    public int OriginId { get; set; }

    public string? OriginName { get; set; }
}
