using InventoryBrother.Application.DTOs.Contacts;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public CustomerService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CustomerDto>> GetAllCustomersAsync(int storeId)
    {
        return await _dbContext.Customers
            .Where(c => c.StoreId == storeId)
            .OrderBy(c => c.CustomerName)
            .Select(c => new CustomerDto
            {
                CustomerId = long.Parse(c.CustomerId ?? "0"),
                CustomerName = c.CustomerName ?? "Unknown",
                MobileNumber = c.CustomerMobile,
                EmailAddress = c.CustomerEmail,
                ContactPerson = c.ContactPerson,
                CustomerAddress = c.CustomerAddress
            })
            .ToListAsync();
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(long customerId)
    {
        var customerIdStr = customerId.ToString();
        var c = await _dbContext.Customers
            .FirstOrDefaultAsync(x => x.CustomerId == customerIdStr);
        
        if (c == null) return null;

        return new CustomerDto
        {
            CustomerId = long.Parse(c.CustomerId ?? "0"),
            CustomerName = c.CustomerName ?? "Unknown",
            MobileNumber = c.CustomerMobile,
            EmailAddress = c.CustomerEmail,
            ContactPerson = c.ContactPerson,
            CustomerAddress = c.CustomerAddress
        };
    }

    public async Task<bool> CreateCustomerAsync(CreateUpdateCustomerDto dto, string userId, int storeId)
    {
        try
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(), // Assuming string ID
                CustomerName = dto.CustomerName,
                CustomerMobile = dto.MobileNumber,
                CustomerEmail = dto.EmailAddress,
                ContactPerson = dto.ContactPerson,
                CustomerAddress = dto.CustomerAddress,
                AreaCode = dto.AreaCode?.ToString(),
                CreatedBy = userId,
                StoreId = storeId,
                CreatedAt = DateTime.Now
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateCustomerAsync(long customerId, CreateUpdateCustomerDto dto, string userId)
    {
        try
        {
            var customerIdStr = customerId.ToString();
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(x => x.CustomerId == customerIdStr);

            if (customer == null) return false;

            customer.CustomerName = dto.CustomerName;
            customer.CustomerMobile = dto.MobileNumber;
            customer.CustomerEmail = dto.EmailAddress;
            customer.ContactPerson = dto.ContactPerson;
            customer.CustomerAddress = dto.CustomerAddress;
            customer.AreaCode = dto.AreaCode?.ToString();
            customer.UpdatedBy = userId;
            customer.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
