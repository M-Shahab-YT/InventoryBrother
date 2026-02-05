using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblManufacturer")]
public partial class Manufacturer : BaseEntity
{
    [Key]
    public int ManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }
}
