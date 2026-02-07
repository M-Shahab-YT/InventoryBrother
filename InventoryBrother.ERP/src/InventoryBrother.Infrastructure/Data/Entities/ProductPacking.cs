using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class ProductPacking : BaseEntity
{
    [Key]
    public int PackingId { get; set; }

    public string? PackingName { get; set; }
}
