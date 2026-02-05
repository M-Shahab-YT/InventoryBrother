using InventoryBrother.Application.DTOs.Finance;

namespace InventoryBrother.Application.Interfaces;

public interface IFinanceService
{
    Task<List<CashAccountDto>> GetCashAccountsAsync(int storeId);
    Task<List<TransactionDto>> GetCustomerStatementAsync(int customerId, DateTime from, DateTime to);
    Task<List<TransactionDto>> GetSupplierStatementAsync(int supplierId, DateTime from, DateTime to);
}
