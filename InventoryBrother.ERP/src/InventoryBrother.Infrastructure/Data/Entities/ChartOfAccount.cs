using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class ChartOfAccount : BaseEntity
{
    [Key]
    public int AccountId { get; set; }

    [MaxLength(20)]
    public string? AccountCode { get; set; } // e.g. 1000, 2100

    [Required]
    [MaxLength(100)]
    public string AccountName { get; set; } = null!;

    [MaxLength(50)]
    public string? AccountType { get; set; } // Detailed type e.g. "Bank", "Accounts Receivable"

    [MaxLength(20)]
    public string? AccountNature { get; set; } // Major type: "Asset", "Liability", "Equity", "Income", "Expense"

    public int? ParentAccountId { get; set; }
    [ForeignKey("ParentAccountId")]
    public virtual ChartOfAccount? ParentAccount { get; set; }

    public bool IsActive { get; set; } = true;
}
