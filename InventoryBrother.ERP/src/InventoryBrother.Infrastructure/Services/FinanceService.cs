using InventoryBrother.Application.DTOs.Finance;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class FinanceService : IFinanceService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public FinanceService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CashAccountDto>> GetCashAccountsAsync(int storeId)
    {
        var accounts = await _dbContext.CashAccounts
            .Where(a => a.StoreId == storeId)
            .ToListAsync();

        var result = new List<CashAccountDto>();
        foreach (var acc in accounts)
        {
            // Sum transactions to get current balance
            var inOut = await _dbContext.CashAccountTransactions
                .Where(d => d.AccountId == acc.AccountId)
                .ToListAsync();

            decimal balance = (acc.OpeningBalance ?? 0) + inOut.Sum(d => (d.InOutStatus == "In" ? (d.Amount ?? 0) : -(d.Amount ?? 0)));

            result.Add(new CashAccountDto
            {
                AccountId = acc.AccountId,
                AccountName = acc.AccountName ?? "Unknown",
                Balance = balance
            });
        }

        return result;
    }

    public async Task<List<TransactionDto>> GetCustomerStatementAsync(int customerId, DateTime from, DateTime to)
    {
        var trans = await _dbContext.CustomerStatements
            .Where(t => t.CustomerId == customerId.ToString() && t.Date >= from && t.Date <= to)
            .OrderBy(t => t.Date)
            .ToListAsync();

        decimal runningBalance = 0; // Need initial balance logic? Assuming 0 for range or need to fetch opening balance
        // For accurate Statement, we should fetch previous balance
        var previousBalance = await _dbContext.CustomerStatements
            .Where(t => t.CustomerId == customerId.ToString() && t.Date < from)
            .SumAsync(t => (t.Debit ?? 0) - (t.Credit ?? 0));
        
        runningBalance = previousBalance;

        var result = new List<TransactionDto>();
        foreach(var t in trans)
        {
            runningBalance += (t.Debit ?? 0) - (t.Credit ?? 0);
            result.Add(new TransactionDto
            {
                Id = (int)t.Sno,
                Date = t.Date ?? DateTime.Now,
                ReferenceNumber = t.ReferenceNumber ?? string.Empty,
                Particulars = t.Particulars ?? string.Empty,
                Debit = t.Debit ?? 0,
                Credit = t.Credit ?? 0,
                Balance = runningBalance
            });
        }
        return result;
    }

    public async Task<List<TransactionDto>> GetSupplierStatementAsync(int supplierId, DateTime from, DateTime to)
    {
        var trans = await _dbContext.SupplierStatements
            .Where(t => t.SupplierId == supplierId.ToString() && t.Date >= from && t.Date <= to)
            .OrderBy(t => t.Date)
            .ToListAsync();

        decimal runningBalance = 0;
        // Calculate opening balance
        // Supplier Statement usually: Credit (Purchase) increases payable, Debit (Payment) decreases payable.
        // Or if SupplierId based: Credit is "We owe them", Debit is "We paid".
        // BaseEntity logic: PurchaseService adds Credit for Purchase, Debit for Payment.
        // Balance = Credit - Debit (Amount Payable to Supplier)
        
        var previousBalance = await _dbContext.SupplierStatements
            .Where(t => t.SupplierId == supplierId.ToString() && t.Date < from)
            .SumAsync(t => (t.Credit ?? 0) - (t.Debit ?? 0));
            
        runningBalance = previousBalance;

        var result = new List<TransactionDto>();
        foreach(var t in trans)
        {
            runningBalance += (t.Credit ?? 0) - (t.Debit ?? 0);
            result.Add(new TransactionDto
            {
                Id = (int)t.Sno,
                Date = t.Date ?? DateTime.Now,
                ReferenceNumber = t.ReferenceNumber ?? string.Empty,
                Particulars = t.Particulars ?? string.Empty,
                Debit = t.Debit ?? 0,
                Credit = t.Credit ?? 0,
                Balance = runningBalance
            });
        }
        return result;
    }
}
