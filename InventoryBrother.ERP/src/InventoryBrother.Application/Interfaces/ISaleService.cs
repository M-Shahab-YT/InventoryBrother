using InventoryBrother.Application.DTOs.Sales;
using InventoryBrother.Application.DTOs.Reports;

namespace InventoryBrother.Application.Interfaces;

public interface ISaleService
{
    Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto saleDto);
    Task<string> GenerateInvoiceNumberAsync();
    Task<InvoiceModel?> GetInvoiceDetailsAsync(string invoiceNo);
    Task<List<SaleListDto>> GetSalesAsync(DateTime from, DateTime to);
}
