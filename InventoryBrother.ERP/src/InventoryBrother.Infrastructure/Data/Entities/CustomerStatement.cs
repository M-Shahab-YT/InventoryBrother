using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblCustomerStatement")]
public partial class CustomerStatement : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public string? CustomerId { get; set; }

    public string? ReferenceType { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? Date { get; set; }

    public string? Particulars { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }

    public DateTime? LastUpdatedDate { get; set; }
}
