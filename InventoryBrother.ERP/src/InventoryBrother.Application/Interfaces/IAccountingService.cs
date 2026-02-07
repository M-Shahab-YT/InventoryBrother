using System.Threading.Tasks;
using InventoryBrother.Application.DTOs.Accounting;

namespace InventoryBrother.Application.Interfaces;

public interface IAccountingService
{
    Task<bool> CreateJournalEntryAsync(JournalEntryDto entry);
    Task<bool> PostSaleAsync(long saleOrderId); // Automated posting
    Task<bool> PostPurchaseAsync(long purchaseOrderId); // Automated posting
    
    Task<TrialBalanceDto> GetTrialBalanceAsync();
    Task<ProfitLossDto> GetProfitLossAsync(DateTime from, DateTime to);
}
