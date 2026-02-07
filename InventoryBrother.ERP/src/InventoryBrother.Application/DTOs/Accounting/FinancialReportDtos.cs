using System.Collections.Generic;

namespace InventoryBrother.Application.DTOs.Accounting;

public class TrialBalanceDto
{
    public List<TrialBalanceLineDto> Lines { get; set; } = new();
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
}

public class TrialBalanceLineDto
{
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}

public class ProfitLossDto
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal NetProfit => TotalIncome - TotalExpense;
    public List<NatureSummaryDto> IncomeDetails { get; set; } = new();
    public List<NatureSummaryDto> ExpenseDetails { get; set; } = new();
}

public class NatureSummaryDto
{
    public string AccountName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
