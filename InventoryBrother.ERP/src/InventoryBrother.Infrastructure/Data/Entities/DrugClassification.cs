using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblDrugClassification")]
public partial class DrugClassification : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? ClassificationName { get; set; }
}
