using InventoryBrother.Application.DTOs.Purchases;

namespace InventoryBrother.Application.Interfaces;

public interface IPurchaseService
{
    Task<PurchaseResponseDto> CreatePurchaseAsync(CreatePurchaseDto purchaseDto, string userId, int storeId);
    Task<string> GeneratePurchaseOrderNoAsync();
}
