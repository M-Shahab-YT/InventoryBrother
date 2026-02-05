using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProductGenericName")]
public partial class ProductGenericName : BaseEntity
{
    [Key]
    public int GenericId { get; set; }

    public string? GenericName { get; set; }
}
