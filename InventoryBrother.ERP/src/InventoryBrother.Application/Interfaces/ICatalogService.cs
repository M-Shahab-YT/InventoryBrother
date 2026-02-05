using InventoryBrother.Application.DTOs.Catalog;

namespace InventoryBrother.Application.Interfaces;

public interface ICatalogService
{
    Task<List<ProductLookupDto>> SearchProductsAsync(string searchTerm);
    Task<List<StockLookupDto>> GetStockForProductAsync(string productCode);
}
