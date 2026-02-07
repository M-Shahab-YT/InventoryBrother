using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

public class JournalEntryLine : BaseEntity
{
    [Key]
    public long Id { get; set; }

    public long JournalEntryId { get; set; }
    [ForeignKey("JournalEntryId")]
    public virtual JournalEntry JournalEntry { get; set; } = null!;

    public int AccountId { get; set; }
    [ForeignKey("AccountId")]
    public virtual ChartOfAccount Account { get; set; } = null!;

    public string? Description { get; set; } // Line description if different from header

    [Column(TypeName = "decimal(18,2)")]
    public decimal Debit { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Credit { get; set; }
}
