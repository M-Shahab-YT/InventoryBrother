using InventoryBrother.Application.DTOs.Contacts;

namespace InventoryBrother.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllCustomersAsync(int storeId);
    Task<CustomerDto?> GetCustomerByIdAsync(long customerId);
    Task<bool> CreateCustomerAsync(CreateUpdateCustomerDto customer, string userId, int storeId);
    Task<bool> UpdateCustomerAsync(long customerId, CreateUpdateCustomerDto customer, string userId);
}

public interface ISupplierService
{
    Task<List<SupplierDto>> GetAllSuppliersAsync(int storeId);
    Task<SupplierDto?> GetSupplierByIdAsync(int supplierId);
    Task<bool> CreateSupplierAsync(CreateUpdateSupplierDto supplier, string userId, int storeId);
    Task<bool> UpdateSupplierAsync(int supplierId, CreateUpdateSupplierDto supplier, string userId);
}
