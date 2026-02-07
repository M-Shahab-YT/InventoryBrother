using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Data;

public class DataSeeder : IDataSeeder
{
    private readonly InventoryBrotherDbContext _dbContext;

    public DataSeeder(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        await SeedChartOfAccountsAsync();
    }

    private async Task SeedChartOfAccountsAsync()
    {
        if (await _dbContext.ChartOfAccounts.AnyAsync(c => c.AccountCode != null)) 
            return; // Already seeded with modern structure

        // 1. Assets
        var assets = await CreateAccount("1000", "Assets", "Asset", null);
        await CreateAccount("1001", "Cash on Hand", "Cash", assets.AccountId);
        await CreateAccount("1002", "Bank Accounts", "Bank", assets.AccountId);
        await CreateAccount("1003", "Accounts Receivable", "Accounts Receivable", assets.AccountId);
        await CreateAccount("1004", "Inventory Asset", "Other Current Asset", assets.AccountId);

        // 2. Liabilities
        var liabilities = await CreateAccount("2000", "Liabilities", "Liability", null);
        await CreateAccount("2001", "Accounts Payable", "Accounts Payable", liabilities.AccountId);
        await CreateAccount("2002", "Sales Tax Payable", "Other Current Liability", liabilities.AccountId);

        // 3. Equity
        var equity = await CreateAccount("3000", "Equity", "Equity", null);
        await CreateAccount("3001", "Owner's Equity", "Equity", equity.AccountId);
        await CreateAccount("3002", "Retained Earnings", "Equity", equity.AccountId);

        // 4. Income
        var income = await CreateAccount("4000", "Income", "Income", null);
        await CreateAccount("4001", "Sales Income", "Income", income.AccountId);
        await CreateAccount("4002", "Service Revenue", "Income", income.AccountId);

        // 5. Expenses
        var expenses = await CreateAccount("5000", "Expenses", "Expense", null);
        await CreateAccount("5001", "Cost of Goods Sold (COGS)", "Cost of Goods Sold", expenses.AccountId);
        await CreateAccount("5002", "Rent Expense", "Expense", expenses.AccountId);
        await CreateAccount("5003", "Utility Expense", "Expense", expenses.AccountId);
        await CreateAccount("5004", "Salary Expense", "Expense", expenses.AccountId);
    }

    private async Task<ChartOfAccount> CreateAccount(string code, string name, string type, int? parentId)
    {
        var nature = DetermineNature(code);
        
        var account = new ChartOfAccount
        {
            AccountCode = code,
            AccountName = name,
            AccountType = type,
            AccountNature = nature,
            ParentAccountId = parentId,
            IsActive = true
        };

        _dbContext.ChartOfAccounts.Add(account);
        await _dbContext.SaveChangesAsync();
        return account;
    }

    private string DetermineNature(string code)
    {
        if (code.StartsWith("1")) return "Asset";
        if (code.StartsWith("2")) return "Liability";
        if (code.StartsWith("3")) return "Equity";
        if (code.StartsWith("4")) return "Income";
        if (code.StartsWith("5")) return "Expense";
        return "Other";
    }
}
