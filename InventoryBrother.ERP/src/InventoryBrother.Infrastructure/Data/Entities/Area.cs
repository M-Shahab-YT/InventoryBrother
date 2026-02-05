using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("LookupTblArea")]
public partial class Area : BaseEntity
{
    [Key]
    public int AreaId { get; set; }

    public string? AreaName { get; set; }
}
