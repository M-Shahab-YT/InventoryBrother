using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("FmisTblCashAccount")]
public partial class CashAccount : BaseEntity
{
    [Key]
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public decimal? OpeningBalance { get; set; }
}
