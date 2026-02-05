using InventoryBrother.Application.DTOs.Catalog;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class CatalogService : ICatalogService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public CatalogService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductLookupDto>> SearchProductsAsync(string searchTerm)
    {
        return await _dbContext.Products
            .Where(p => (p.ProductName != null && p.ProductName.Contains(searchTerm)) || 
                        p.ProductCode.Contains(searchTerm) || 
                        (p.ProductBarCode != null && p.ProductBarCode.Contains(searchTerm)))
            .Take(20)
            .Select(p => new ProductLookupDto
            {
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                Barcode = p.ProductBarCode,
                SalePrice = 0 // Price usually depends on stock/batch, but we can put a default here
            })
            .ToListAsync();
    }

    public async Task<List<StockLookupDto>> GetStockForProductAsync(string productCode)
    {
        return await _dbContext.Stocks
            .Where(s => s.ProductCode == productCode && s.Quantity > 0)
            .Select(s => new StockLookupDto
            {
                Id = s.Id,
                ProductCode = s.ProductCode,
                BatchNo = s.BatchNo,
                ExpiryDate = s.ExpiryDate,
                Quantity = (decimal)(s.Quantity ?? 0),
                AveragePrice = 0 // Would need logic from ImisTblAveragePrice or Similar
            })
            .ToListAsync();
    }
}
