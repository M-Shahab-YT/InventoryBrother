using InventoryBrother.Application.DTOs.Catalog;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public ProductService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductListDto>> GetProductsAsync(ProductSearchFilter filter)
    {
        var query = _dbContext.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        {
            query = query.Where(p => (p.ProductName != null && p.ProductName.Contains(filter.SearchTerm)) || 
                                     (p.ProductBarCode != null && p.ProductBarCode.Contains(filter.SearchTerm)) ||
                                     p.ProductCode.Contains(filter.SearchTerm));
        }

        if (filter.CategoryId.HasValue)
        {
            query = query.Where(p => p.ProductCategoryId == filter.CategoryId.Value);
        }

        if (filter.LowStockOnly)
        {
            // Sum stock per product and compare with MinimumStockQty
            // This is complex in EF Core with multi-table join if we want it efficient
            // For now, simple filter on MinimumStockQty > 0
            query = query.Where(p => p.MinimumStockQty > 0);
        }

        var products = await query.Take(100).ToListAsync();
        var resultList = new List<ProductListDto>();

        foreach (var p in products)
        {
            var stocks = await _dbContext.Stocks
                .Where(s => s.ProductCode == p.ProductCode)
                .ToListAsync();
            
            decimal currentStock = (decimal)stocks.Sum(s => s.Quantity ?? 0);

            if (filter.LowStockOnly && currentStock >= (decimal)(p.MinimumStockQty ?? 0))
                continue;

            resultList.Add(new ProductListDto
            {
                ProductCode = p.ProductCode,
                ProductName = p.ProductName ?? string.Empty,
                ProductBarCode = p.ProductBarCode,
                SalePrice = (decimal)(p.SalePrice ?? 0),
                CurrentStock = currentStock,
                MinimumStockQty = (decimal)(p.MinimumStockQty ?? 0)
            });
        }

        return resultList;
    }

    public async Task<ProductDetailDto?> GetProductDetailAsync(string productCode)
    {
        var p = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.ProductCode == productCode);

        if (p == null) return null;

        return new ProductDetailDto
        {
            ProductCode = p.ProductCode,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            ProductBarCode = p.ProductBarCode,
            ProductCategoryId = p.ProductCategoryId,
            SalePrice = (decimal)(p.SalePrice ?? 0),
            Mrp = (decimal)(p.Mrp ?? 0),
            Discount = (decimal)(p.Discount ?? 0),
            MinimumStockQty = (decimal)(p.MinimumStockQty ?? 0)
        };
    }

    public async Task<bool> UpdateProductAsync(ProductDetailDto product)
    {
        var p = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.ProductCode == product.ProductCode);

        if (p == null) return false;

        p.ProductName = product.ProductName;
        p.ProductDescription = product.ProductDescription;
        p.ProductBarCode = product.ProductBarCode;
        p.ProductCategoryId = product.ProductCategoryId;
        p.SalePrice = (double)product.SalePrice;
        p.Mrp = (double)product.Mrp;
        p.Discount = (double)product.Discount;
        p.MinimumStockQty = (double)product.MinimumStockQty;
        p.UpdatedAt = DateTime.Now;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AdjustStockAsync(StockAdjustmentDto adjustment, string userId, int storeId)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(s => s.Id == adjustment.StockId);

            if (stock == null) return false;

            double oldQty = stock.Quantity ?? 0;
            stock.Quantity = (double)adjustment.NewQuantity;

            // Log History
            var history = new StockHistory
            {
                StockId = stock.Id,
                ProductCode = stock.ProductCode,
                Quantity = oldQty,
                NewQuantity = (double)adjustment.NewQuantity,
                StoreId = storeId,
                CreatedBy = userId,
                CreatedAt = DateTime.Now,
                Remarks = adjustment.Remarks ?? "Manual Adjustment",
                AveragePrice = stock.StockPrice
            };

            _dbContext.StockHistories.Add(history);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}
