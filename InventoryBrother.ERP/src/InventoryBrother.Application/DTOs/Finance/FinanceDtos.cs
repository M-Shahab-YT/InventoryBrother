using System;

namespace InventoryBrother.Application.DTOs.Finance;

public class CashAccountDto
{
    public long AccountId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string? CurrencyName { get; set; }
}

public class TransactionDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public string Particulars { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
}

public class StatementFilterDto
{
    public int? CustomerId { get; set; }
    public int? SupplierId { get; set; }
    public DateTime FromDate { get; set; } = DateTime.Now.AddMonths(-1);
    public DateTime ToDate { get; set; } = DateTime.Now;
}
