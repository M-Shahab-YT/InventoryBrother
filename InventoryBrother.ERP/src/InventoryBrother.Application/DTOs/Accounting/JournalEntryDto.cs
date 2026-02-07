using System;
using System.Collections.Generic;

namespace InventoryBrother.Application.DTOs.Accounting;

public class JournalEntryDto
{
    public DateTime Date { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsAutoPosted { get; set; }
    public List<JournalEntryLineDto> Lines { get; set; } = new();
}

public class JournalEntryLineDto
{
    public int AccountId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}
