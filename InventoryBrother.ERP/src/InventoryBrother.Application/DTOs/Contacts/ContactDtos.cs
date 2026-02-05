using System;

namespace InventoryBrother.Application.DTOs.Contacts;

public class CustomerDto
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string? MobileNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? ContactPerson { get; set; }
    public string? CustomerAddress { get; set; }
}

public class CreateUpdateCustomerDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string? MobileNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? ContactPerson { get; set; }
    public string? CustomerAddress { get; set; }
    public long? AreaCode { get; set; }
}

public class SupplierDto
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string? SupplierAddress { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactMobileNo { get; set; }
    public decimal OpeningBalance { get; set; }
}

public class CreateUpdateSupplierDto
{
    public string SupplierName { get; set; } = string.Empty;
    public string? SupplierAddress { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactMobileNo { get; set; }
    public decimal OpeningBalance { get; set; }
    public string? Country { get; set; }
}
