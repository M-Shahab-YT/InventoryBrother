using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class CashAccountTransaction : BaseEntity
{
    [Key]
    public long Sno { get; set; }

    public int? AccountId { get; set; }

    public string? EntryReference { get; set; }

    public string? EntryReferenceNumber { get; set; }



    public string? Remarks { get; set; }

    public decimal? Amount { get; set; }

    public string? InOutStatus { get; set; }
}
