using InventoryBrother.Application.DTOs.Purchases;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class PurchaseService : IPurchaseService
{
    private readonly InventoryBrotherDbContext _dbContext;
    private readonly IAccountingService _accountingService;

    public PurchaseService(InventoryBrotherDbContext dbContext, IAccountingService accountingService)
    {
        _dbContext = dbContext;
        _accountingService = accountingService;
    }

    public async Task<string> GeneratePurchaseOrderNoAsync()
    {
        var lastOrder = await _dbContext.PurchaseOrders
            .OrderByDescending(o => o.Sno)
            .FirstOrDefaultAsync();

        int nextId = (int)(lastOrder?.Sno ?? 0) + 1;
        return $"PO-{DateTime.Now:yyyyMMdd}-{nextId:D4}";
    }

    public async Task<PurchaseResponseDto> CreatePurchaseAsync(CreatePurchaseDto dto, string userId, int storeId)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            string poNo = await GeneratePurchaseOrderNoAsync();
            decimal totalAmount = (decimal)dto.Items.Sum(i => i.Quantity * i.PurchasePrice);

            // 1. Create Main Record
            var main = new PurchaseOrder
            {
                PurchaseOrderNo = poNo,
                OrderReceivedDate = DateOnly.FromDateTime(DateTime.Now),
                SupplierId = dto.SupplierId.ToString(),
                InvoiceNo = dto.InvoiceNo,
                PaymentMethod = dto.PaymentMethod,
                CurrencyId = dto.CurrencyId,
                ExchangeRate = dto.ExchangeRate,
                TotalOrderAmount = totalAmount,
                AmountPaidToSupplier = dto.AmountPaid,
                BalanceAmount = totalAmount - dto.AmountPaid,
                PaymentStatus = (totalAmount <= dto.AmountPaid) ? "Paid" : "Partial",
                CreatedBy = userId,
                StoreId = storeId,
                CreatedAt = DateTime.Now,
                Remarks = dto.Remarks
            };

            _dbContext.PurchaseOrders.Add(main);

            // 2. Process Details & Stock
            foreach (var item in dto.Items)
            {
                var detail = new PurchaseOrderItem
                {
                    PurchaseOrderNo = poNo,
                    ProductCode = item.ProductCode,
                    BatchNo = item.BatchNo,
                    ExpiryDate = item.ExpiryDate,
                    CurrencyId = dto.CurrencyId,
                    ExchangeRate = (double)dto.ExchangeRate,
                    PurchasePrice = (decimal)item.PurchasePrice,
                    Quantity = item.Quantity,
                    Total = (decimal)(item.Quantity * item.PurchasePrice),
                    CreatedBy = userId,
                    StoreId = storeId,
                    CreatedAt = DateTime.Now
                };
                _dbContext.PurchaseOrderItems.Add(detail);

                // Update Stock
                var stock = await _dbContext.Stocks
                    .FirstOrDefaultAsync(s => s.ProductCode == item.ProductCode && s.BatchNo == item.BatchNo && s.StoreId == storeId);

                if (stock != null)
                {
                    stock.Quantity += item.Quantity;
                }
                else
                {
                    stock = new Stock
                    {
                        ProductCode = item.ProductCode,
                        BatchNo = item.BatchNo,
                        ExpiryDate = item.ExpiryDate?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now.AddYears(2),
                        Quantity = item.Quantity,
                        StockPrice = item.PurchasePrice,
                        StoreId = storeId,
                        UpdatedBy = userId,
                        UpdatedAt = DateTime.Now,
                        Remarks = $"Purchase {poNo}"
                    };
                    _dbContext.Stocks.Add(stock);
                }
            }

            // 3. Finance: Supplier Statement
            // Credit (Purchase Amount)
            var supplierCredit = new SupplierStatement
            {
                SupplierId = dto.SupplierId.ToString(),
                StoreId = storeId,
                ReferenceType = "Purchase Invoice",
                ReferenceNumber = poNo,
                Date = DateTime.Now,
                Particulars = $"Purchase Invoice {dto.InvoiceNo}",
                Debit = 0,
                Credit = totalAmount,
                CreatedBy = userId,
                // LastUpdatedDate removed/mapped to UpdatedAt if needed, but handled by BaseEntity defaults or specific update logic
            };
            _dbContext.SupplierStatements.Add(supplierCredit);

            if (dto.AmountPaid > 0)
            {
                // Debit (Payment)
                var supplierDebit = new SupplierStatement
                {
                    SupplierId = dto.SupplierId.ToString(),
                    StoreId = storeId,
                    ReferenceType = "Payment",
                    ReferenceNumber = poNo,
                    Date = DateTime.Now,
                    Particulars = $"Payment for PO {poNo}",
                    Debit = dto.AmountPaid,
                    Credit = 0,
                    CreatedBy = userId,
                    UpdatedAt = DateTime.Now
                };
                _dbContext.SupplierStatements.Add(supplierDebit);

                // Money out from Cash Account
                var cashEntry = new CashAccountTransaction
                {
                    AccountId = 1, // Default Cash Account
                    EntryReference = "Purchase Payment",
                    EntryReferenceNumber = poNo,
                    CreatedAt = DateTime.Now,
                    Remarks = $"Payment to Supplier for PO {poNo}",
                    Amount = dto.AmountPaid,
                    InOutStatus = "Out",
                    CreatedBy = userId,
                    StoreId = storeId
                };
                _dbContext.CashAccountTransactions.Add(cashEntry);
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            try { await _accountingService.PostPurchaseAsync(main.Sno); } catch { /* log error */ }

            return new PurchaseResponseDto { Success = true, PurchaseOrderNo = poNo };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return new PurchaseResponseDto { Success = false, Message = ex.Message };
        }
    }
}
