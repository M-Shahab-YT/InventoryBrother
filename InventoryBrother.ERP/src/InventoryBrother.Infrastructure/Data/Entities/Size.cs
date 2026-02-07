using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class Size : BaseEntity
{
    [Key]
    public int SizeId { get; set; }

    public string? SizeName { get; set; }
}
