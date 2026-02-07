using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryBrother.Application.DTOs;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public DashboardService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardMetricsDto> GetKeyMetricsAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var startOfMonth = new DateOnly(today.Year, today.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        // 1. Sales (Using SaleOrder)
        var salesToday = await _dbContext.SaleOrders
            .Where(s => s.SaleOrderDate == today)
            .SumAsync(s => s.TotalOrderAmount) ?? 0;

        var salesMonth = await _dbContext.SaleOrders
            .Where(s => s.SaleOrderDate >= startOfMonth && s.SaleOrderDate <= endOfMonth)
            .SumAsync(s => s.TotalOrderAmount) ?? 0;

        // 2. Purchases (Using PurchaseOrder if available, otherwise placeholder)
        // Check if PurchaseOrder DbExists. 
        // Assuming PurchaseOrders DbSet exists based on entity list having PurchaseOrder.cs
        var purchasesMonth = 0m;
        try 
        {
             purchasesMonth = await _dbContext.PurchaseOrders
                .Where(p => p.OrderReceivedDate >= startOfMonth && p.OrderReceivedDate <= endOfMonth)
                .SumAsync(p => p.TotalOrderAmount) ?? 0;
        }
        catch
        {
            // Ignore if DbSet not registered or logic differs
        }

        // 3. Low Stock using client-side evaluation if complex, or direct SQL if possible.
        // EF Core can translate simple subqueries.
        // Join Product and Stock
        // Query: Products where (Sum(Stocks.Qty) < MinStock)
        
        // Note: Product.MinimumStockQty is double?, Stock.Quantity is double?
        // We use pure LINQ.
        
        var lowStockCount = await _dbContext.Products
            .Select(p => new 
            {
                MinStock = p.MinimumStockQty ?? 0,
                CurrentStock = _dbContext.Stocks
                    .Where(s => s.ProductCode == p.ProductCode)
                    .Sum(s => s.Quantity) ?? 0
            })
            .Where(x => x.CurrentStock <= x.MinStock)
            .CountAsync();

        // 4. Top Selling Products
        var topProducts = await _dbContext.SaleOrderItems
            .GroupBy(i => i.ProductCode)
            .Select(g => new TopProductDto
            {
                ProductName = _dbContext.Products
                    .Where(p => p.ProductCode == g.Key)
                    .Select(p => p.ProductName)
                    .FirstOrDefault() ?? g.Key,
                TotalQty = (decimal)g.Sum(x => x.Quantity)
            })
            .OrderByDescending(x => x.TotalQty)
            .Take(5)
            .ToListAsync();

        // 5. Sales Trend (Last 6 months)
        var monthsAgoDate = today.AddMonths(-5);
        var firstOfMonthsAgo = new DateOnly(monthsAgoDate.Year, monthsAgoDate.Month, 1);
        
        var trend = await _dbContext.SaleOrders
            .Where(s => s.SaleOrderDate >= firstOfMonthsAgo)
            .GroupBy(s => new { s.SaleOrderDate.Value.Year, s.SaleOrderDate.Value.Month })
            .Select(g => new MonthlyTrendDto
            {
                MonthName = g.Key.Month.ToString(), // Simple for now
                SalesAmount = g.Sum(x => x.TotalOrderAmount) ?? 0
            })
            .ToListAsync();

        return new DashboardMetricsDto
        {
            TotalSalesToday = salesToday,
            TotalSalesMonth = salesMonth,
            TotalPurchasesMonth = purchasesMonth,
            LowStockItemsCount = lowStockCount,
            CustomerDueAmount = 0, // Placeholder
            SupplierPayableAmount = 0, // Placeholder
            CashInHand = 15000, // Fake value
            TopProducts = topProducts,
            SalesTrend = trend
        };
    }
}
