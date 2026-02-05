using InventoryBrother.Application.DTOs.Catalog;

namespace InventoryBrother.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductListDto>> GetProductsAsync(ProductSearchFilter filter);
    Task<ProductDetailDto?> GetProductDetailAsync(string productCode);
    Task<bool> UpdateProductAsync(ProductDetailDto product);
    Task<bool> AdjustStockAsync(StockAdjustmentDto adjustment, string userId, int storeId);
}
