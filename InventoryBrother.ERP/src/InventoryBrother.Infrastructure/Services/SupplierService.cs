using InventoryBrother.Application.DTOs.Contacts;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class SupplierService : ISupplierService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public SupplierService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SupplierDto>> GetAllSuppliersAsync(int storeId)
    {
        return await _dbContext.Suppliers
            .Where(s => s.StoreId == storeId)
            .OrderBy(s => s.SupplierName)
            .Select(s => new SupplierDto
            {
                SupplierId = int.Parse(s.SupplierId),
                SupplierName = s.SupplierName ?? "Unknown",
                SupplierAddress = s.SupplierAddress,
                ContactPerson = s.ContactPerson,
                ContactEmail = s.SupplierEmail,
                ContactMobileNo = s.SupplierMobile,
                OpeningBalance = s.OpeningBalance ?? 0
            })
            .ToListAsync();
    }

    public async Task<SupplierDto?> GetSupplierByIdAsync(int supplierId)
    {
        var supplierIdStr = supplierId.ToString();
        var s = await _dbContext.Suppliers
            .FirstOrDefaultAsync(x => x.SupplierId == supplierIdStr);

        if (s == null) return null;

        return new SupplierDto
        {
            SupplierId = int.Parse(s.SupplierId),
            SupplierName = s.SupplierName ?? "Unknown",
            SupplierAddress = s.SupplierAddress,
            ContactPerson = s.ContactPerson,
            ContactEmail = s.SupplierEmail,
            ContactMobileNo = s.SupplierMobile,
            OpeningBalance = s.OpeningBalance ?? 0
        };
    }

    public async Task<bool> CreateSupplierAsync(CreateUpdateSupplierDto dto, string userId, int storeId)
    {
        try
        {
            var supplier = new Supplier
            {
                SupplierId = Guid.NewGuid().ToString(), // Assuming string ID
                SupplierName = dto.SupplierName,
                SupplierAddress = dto.SupplierAddress,
                ContactPerson = dto.ContactPerson,
                SupplierEmail = dto.ContactEmail,
                SupplierMobile = dto.ContactMobileNo,
                OpeningBalance = dto.OpeningBalance,
                CreatedBy = userId,
                StoreId = storeId,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateSupplierAsync(int supplierId, CreateUpdateSupplierDto dto, string userId)
    {
        try
        {
            var supplierIdStr = supplierId.ToString();
            var supplier = await _dbContext.Suppliers
                .FirstOrDefaultAsync(x => x.SupplierId == supplierIdStr);

            if (supplier == null) return false;

            supplier.SupplierName = dto.SupplierName;
            supplier.SupplierAddress = dto.SupplierAddress;
            supplier.ContactPerson = dto.ContactPerson;
            supplier.SupplierEmail = dto.ContactEmail;
            supplier.SupplierMobile = dto.ContactMobileNo;
            supplier.OpeningBalance = dto.OpeningBalance;
            supplier.CreatedBy = userId;
            supplier.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
