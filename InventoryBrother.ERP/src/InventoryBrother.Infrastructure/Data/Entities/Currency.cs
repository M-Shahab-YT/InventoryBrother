using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("LookupTblCurrency")]
public partial class Currency : BaseEntity
{
    [Key]
    public int CurrencyId { get; set; }

    public string? CurrencyName { get; set; }

    public string? CurrencySymbol { get; set; }
}
