using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblBrand")]
public partial class Brand : BaseEntity
{
    [Key]
    public int BrandId { get; set; }

    public string? BrandName { get; set; }
}
