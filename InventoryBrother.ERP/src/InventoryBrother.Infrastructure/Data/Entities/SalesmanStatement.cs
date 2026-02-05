using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblSalesManStatement")]
public partial class SalesmanStatement : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public long? SalesmanId { get; set; }

    public string? ReferenceType { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }
}
