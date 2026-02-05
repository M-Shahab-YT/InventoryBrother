using InventoryBrother.Application.DTOs.Sales;
using InventoryBrother.Application.DTOs.Reports;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class SaleService : ISaleService
{
    private readonly InventoryBrotherDbContext _dbContext;
    private readonly IAuthService _authService;

    public SaleService(InventoryBrotherDbContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }

    public async Task<string> GenerateInvoiceNumberAsync()
    {
        // Simple numeric sequence from legacy logic: GenerateUniquePatientNumber
        // We'll mimic this by finding the max invoice number or using a timestamp based approach
        var lastInvoice = await _dbContext.SaleOrders
            .OrderByDescending(s => s.Sno)
            .FirstOrDefaultAsync();
            
        long nextId = (lastInvoice?.Sno ?? 0) + 1;
        return nextId.ToString();
    }

    public async Task<SaleResponseDto> CreateSaleAsync(CreateSaleDto saleDto)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var invoiceNo = await GenerateInvoiceNumberAsync();
            var storeId = _authService.CurrentStoreId ?? 1;
            var userId = _authService.CurrentUserId ?? "System";

            // 1. Calculate Base Currency values
            decimal baseTotal = ToBase(saleDto.TotalAmount, saleDto.ExchangeRate);
            decimal basePaid = ToBase(saleDto.PaidAmount, saleDto.ExchangeRate);
            decimal baseBalance = baseTotal - basePaid;

            // 2. Create Sale Main Record
            var saleMain = new SaleOrder
            {
                InvoiceNo = invoiceNo,
                CustomerId = saleDto.CustomerId ?? "1",
                PaymentMethod = saleDto.PaymentMethod,
                TotalOrderAmount = saleDto.TotalAmount,
                TotalPaidAmount = saleDto.PaidAmount,
                BalanceAmount = saleDto.TotalAmount - saleDto.PaidAmount,
                CurrencyId = saleDto.CurrencyId,
                ExchangeRate = saleDto.ExchangeRate,
                TotalBaseCurrencyAmount = baseTotal,
                TotalBaseCurrencyPaidAmount = basePaid,
                TotalBaseCurrencyBalanceAmount = baseBalance,
                Remarks = saleDto.Remarks,
                Status = "Sold",
                CreatedBy = userId,
                StoreId = storeId,
                SaleOrderDate = DateOnly.FromDateTime(DateTime.Now),
                SaleOrderTime = TimeOnly.FromDateTime(DateTime.Now)
            };

            _dbContext.SaleOrders.Add(saleMain);

            // 3. Handle Cash Accounts
            if (saleDto.PaymentMethod != "Loan" && saleDto.PaymentAccountId.HasValue)
            {
                var cashDetail = new CashAccountTransaction
                {
                    AccountId = saleDto.PaymentAccountId.Value,
                    Amount = saleDto.PaidAmount,
                    InOutStatus = "In",
                    EntryReference = "Sales",
                    EntryReferenceNumber = invoiceNo,
                    Remarks = saleDto.PaymentMethod,
                    CreatedBy = userId,
                    StoreId = storeId,
                    CreatedAt = DateTime.Now
                };
                _dbContext.CashAccountTransactions.Add(cashDetail);
            }

            // 4. Items and Stock
            foreach (var item in saleDto.Items)
            {
                decimal baseDiscount = ToBase(item.Discount, saleDto.ExchangeRate);
                decimal baseSalePrice = ToBase(item.SalePrice, saleDto.ExchangeRate);
                decimal baseTotalProfit = ((baseSalePrice - baseDiscount) - item.AveragePrice) * item.Quantity;

                var detail = new SaleOrderItem
                {
                    InvoiceNo = invoiceNo,
                    ProductCode = item.ProductCode,
                    BatchNo = item.BatchNo,
                    ExpiryDate = item.ExpiryDate,
                    ProductStockId = (int)item.ProductStockId,
                    Quantity = (double)item.Quantity,
                    BaseCurrencyAveragePrice = (double)item.AveragePrice,
                    SalePrice = (double)item.SalePrice,
                    Discount = (double)item.Discount,
                    CurrencyId = saleDto.CurrencyId,
                    ExchangeRate = (double)saleDto.ExchangeRate,
                    BaseCurrencySalePrice = (double)baseSalePrice,
                    BaseCurrencyDiscount = (double)baseDiscount,
                    BaseCurrencyProfitPerUnit = (double)((baseSalePrice - baseDiscount) - item.AveragePrice),
                    TotalBaseCurrencyProfit = (double)baseTotalProfit,
                    Total = (double)((item.SalePrice - item.Discount) * item.Quantity),
                    BaseCurrencyTotal = (double)((baseSalePrice - baseDiscount) * item.Quantity),
                    Status = "Sold",
                    StoreId = storeId,
                    SalesManId = saleDto.SaleManId?.ToString(),
                    CreatedAt = DateTime.Now
                };
                _dbContext.SaleOrderItems.Add(detail);

                // Update Stock
                var stock = await _dbContext.Stocks
                    .FirstOrDefaultAsync(s => s.Id == item.ProductStockId);
                if (stock != null)
                {
                    stock.Quantity -= (double)item.Quantity;
                }
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return new SaleResponseDto { InvoiceNo = invoiceNo, Success = true };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return new SaleResponseDto { Success = false, Message = ex.Message };
        }
    }

    public async Task<InvoiceModel?> GetInvoiceDetailsAsync(string invoiceNo)
    {
        var saleMain = await _dbContext.SaleOrders
            .FirstOrDefaultAsync(s => s.InvoiceNo == invoiceNo);

        if (saleMain == null) return null;

        var store = await _dbContext.Stores.FirstOrDefaultAsync(s => s.StoreId == saleMain.StoreId);
        var biz = await _dbContext.BusinessInformations.FirstOrDefaultAsync();

        var details = await _dbContext.SaleOrderItems
            .Where(d => d.InvoiceNo == invoiceNo)
            .ToListAsync();

        var model = new InvoiceModel
        {
            BusinessName = biz?.BusinessName ?? "InventoryBrother ERP",
            StoreName = store?.StoreName,
            Address = store?.Address,
            Contact = store?.ContactNumber1,
            InvoiceNo = saleMain.InvoiceNo,
            Date = saleMain.SaleOrderDate?.ToDateTime(TimeOnly.FromDateTime(DateTime.Now)) ?? DateTime.Now,
            GrandTotal = (decimal)(saleMain.TotalOrderAmount ?? 0),
            TotalDiscount = 0, // Need to implement discount logic in main
            NetTotal = (decimal)(saleMain.TotalOrderAmount ?? 0), // Placeholder
            PaidAmount = (decimal)(saleMain.TotalPaidAmount ?? 0),
            BalanceDue = (decimal)(saleMain.BalanceAmount ?? 0),
            CashierName = saleMain.CreatedBy ?? "Unknown"
        };
        
        // Items mapping
        int sno = 1;
        foreach(var d in details)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == d.ProductCode);
            model.Items.Add(new InvoiceItemModel
            {
                SNo = sno++,
                ProductName = product?.ProductName ?? d.ProductCode,
                Quantity = (decimal)d.Quantity,
                Price = (decimal)d.SalePrice,
                Discount = (decimal)d.Discount,
                Total = (decimal)d.Total
            });
        }

        return model;
    }

    private decimal ToBase(decimal amount, decimal rate)
    {
        // For now assuming '*' operator as seen in legacy code base logic
        // In full implementation, we'd fetch the operator from DB
        return amount * rate;
    }
}
