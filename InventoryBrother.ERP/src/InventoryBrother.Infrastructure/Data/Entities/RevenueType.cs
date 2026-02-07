using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class RevenueType : BaseEntity
{
    [Key]
    public int RevenueTypeId { get; set; }

    public string? RevenueTypeName { get; set; }
}
