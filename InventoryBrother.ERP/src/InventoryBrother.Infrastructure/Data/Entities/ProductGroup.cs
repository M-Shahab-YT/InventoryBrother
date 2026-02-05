using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblProductGroup")]
public partial class ProductGroup : BaseEntity
{
    [Key]
    public int GroupId { get; set; }

    public string? GroupName { get; set; }
}
