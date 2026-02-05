using InventoryBrother.Application.DTOs.Reports;

namespace InventoryBrother.Application.Interfaces;

public interface IReportService
{
    Task<byte[]> GenerateStockReportAsync(int storeId);
    Task<byte[]> GenerateSalesSummaryReportAsync(DateTime from, DateTime to, int storeId);
}
