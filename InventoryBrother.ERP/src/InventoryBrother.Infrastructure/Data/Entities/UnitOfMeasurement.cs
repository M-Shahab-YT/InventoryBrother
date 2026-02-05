using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblUnitOfMeasurement")]
public partial class UnitOfMeasurement : BaseEntity
{
    [Key]
    public int UnitId { get; set; }

    public string? UnitName { get; set; }
}
