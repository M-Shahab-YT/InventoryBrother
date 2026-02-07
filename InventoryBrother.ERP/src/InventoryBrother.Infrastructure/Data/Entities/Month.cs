using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class Month : BaseEntity
{
    [Key]
    public int MonthId { get; set; }

    public string? MonthName { get; set; }
}
