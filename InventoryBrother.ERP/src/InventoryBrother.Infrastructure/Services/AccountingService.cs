using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryBrother.Application.DTOs.Accounting;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class AccountingService : IAccountingService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public AccountingService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateJournalEntryAsync(JournalEntryDto entryDto)
    {
        // validation: Debits must equal Credits
        var totalDebit = entryDto.Lines.Sum(l => l.Debit);
        var totalCredit = entryDto.Lines.Sum(l => l.Credit);

        if (Math.Abs(totalDebit - totalCredit) > 0.01m)
        {
            throw new InvalidOperationException($"Journal Entry is not balanced. Debits: {totalDebit}, Credits: {totalCredit}");
        }

        var journalEntry = new JournalEntry
        {
            Date = entryDto.Date,
            ReferenceNumber = entryDto.ReferenceNumber,
            Description = entryDto.Description,
            IsAutoPosted = entryDto.IsAutoPosted,
            CreatedAt = DateTime.Now,
            CreatedBy = "System" // Should get current user
        };

        foreach (var line in entryDto.Lines)
        {
            journalEntry.Lines.Add(new JournalEntryLine
            {
                AccountId = line.AccountId,
                Debit = line.Debit,
                Credit = line.Credit,
                Description = line.Description
            });
        }

        _dbContext.JournalEntries.Add(journalEntry);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PostSaleAsync(long saleOrderId)
    {
        // 1. Get Sale
        var sale = await _dbContext.SaleOrders
            .FirstOrDefaultAsync(s => s.Sno == saleOrderId);
        
        if (sale == null) return false;

        // 2. Identify Accounts (Hardcoded IDs for MVP, usually config based)
        // Asset: Cash (1001) or AR (1002)
        // Income: Sales Income (4001)
        
        // Let's assume account IDs for now, in real app we look them up by Code
        int cashAccountId = 1; // Placeholder
        int salesIncomeAccountId = 2; // Placeholder

        var entry = new JournalEntryDto
        {
            Date = sale.SaleOrderDate?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now,
            ReferenceNumber = sale.InvoiceNo,
            Description = $"Auto-post Sale {sale.InvoiceNo}",
            IsAutoPosted = true,
            Lines = new List<JournalEntryLineDto>
            {
                // Debit Cash/AR
                new JournalEntryLineDto
                {
                    AccountId = cashAccountId,
                    Debit = sale.TotalOrderAmount ?? 0,
                    Credit = 0
                },
                // Credit Sales Income
                new JournalEntryLineDto
                {
                    AccountId = salesIncomeAccountId,
                    Debit = 0,
                    Credit = sale.TotalOrderAmount ?? 0
                }
            }
        };

        return await CreateJournalEntryAsync(entry);
    }

    public async Task<bool> PostPurchaseAsync(long purchaseOrderId)
    {
         var purchase = await _dbContext.PurchaseOrders
            .FirstOrDefaultAsync(p => p.Sno == purchaseOrderId);
        
        if (purchase == null) return false;

        int inventoryAccountId = 3; 
        int cashAccountId = 1;

        var entry = new JournalEntryDto
        {
            Date = purchase.OrderReceivedDate?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now,
            ReferenceNumber = purchase.PurchaseOrderNo,
            Description = $"Auto-post Purchase {purchase.PurchaseOrderNo}",
            IsAutoPosted = true,
            Lines = new List<JournalEntryLineDto>
            {
                // Debit Inventory (Asset)
                new JournalEntryLineDto
                {
                    AccountId = inventoryAccountId,
                    Debit = purchase.TotalOrderAmount ?? 0,
                    Credit = 0
                },
                // Credit Cash/AP
                new JournalEntryLineDto
                {
                    AccountId = cashAccountId,
                    Debit = 0,
                    Credit = purchase.TotalOrderAmount ?? 0
                }
            }
        };

        return await CreateJournalEntryAsync(entry);
    }
    
    public async Task<TrialBalanceDto> GetTrialBalanceAsync()
    {
        // Aggregate all lines by Account
        var lines = await _dbContext.JournalEntryLines
            .Include(l => l.Account)
            .GroupBy(l => new { l.AccountId, l.Account.AccountCode, l.Account.AccountName })
            .Select(g => new 
            {
                Code = g.Key.AccountCode,
                Name = g.Key.AccountName,
                DebitSum = g.Sum(x => x.Debit),
                CreditSum = g.Sum(x => x.Credit)
            })
            .ToListAsync();
            
        var report = new TrialBalanceDto();
        
        foreach(var line in lines)
        {
            decimal netDebit = 0;
            decimal netCredit = 0;
            
            if (line.DebitSum >= line.CreditSum)
                netDebit = line.DebitSum - line.CreditSum;
            else
                netCredit = line.CreditSum - line.DebitSum;

            if (netDebit == 0 && netCredit == 0) continue;

            report.Lines.Add(new TrialBalanceLineDto
            {
                AccountCode = line.Code ?? "",
                AccountName = line.Name,
                Debit = netDebit,
                Credit = netCredit
            });
        }

        report.TotalDebit = report.Lines.Sum(l => l.Debit);
        report.TotalCredit = report.Lines.Sum(l => l.Credit);

        return report;
    }

    public async Task<ProfitLossDto> GetProfitLossAsync(DateTime from, DateTime to)
    {
        // Filter by Date inside Join
        var lines = await _dbContext.JournalEntryLines
            .Include(l => l.Account)
            .Where(l => l.JournalEntry.Date >= from && l.JournalEntry.Date <= to)
            .Where(l => l.Account.AccountNature == "Income" || l.Account.AccountNature == "Expense")
            .GroupBy(l => new { l.AccountId, l.Account.AccountName, l.Account.AccountNature })
            .Select(g => new 
            {
                Nature = g.Key.AccountNature,
                AccountName = g.Key.AccountName,
                DebitSum = g.Sum(x => x.Debit),
                CreditSum = g.Sum(x => x.Credit)
            })
            .ToListAsync();

        var report = new ProfitLossDto();

        foreach(var line in lines)
        {
            // Income is Credit normal, Expense is Debit normal
            decimal amount = 0;
            if (line.Nature == "Income")
            {
                amount = line.CreditSum - line.DebitSum;
                report.IncomeDetails.Add(new NatureSummaryDto { AccountName = line.AccountName, Amount = amount });
                report.TotalIncome += amount;
            }
            else // Expense
            {
                 amount = line.DebitSum - line.CreditSum;
                 report.ExpenseDetails.Add(new NatureSummaryDto { AccountName = line.AccountName, Amount = amount });
                 report.TotalExpense += amount;
            }
        }

        return report;
    }
}
