using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblStore")]
public partial class Store : BaseEntity
{
    [Key]
    public new int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? Address { get; set; }

    public string? ContactNumber1 { get; set; }

    public string? ContactNumber2 { get; set; }

    public string? Email { get; set; }

    public string? StoreDescription { get; set; }

    public string? Status { get; set; }
    public string? AddressLocal { get; set; }
    public string? BusinessLogo { get; set; }
    public string? StoreGpspoints { get; set; }
    public string? StoreNameLocal { get; set; }

    // Audit fields are in BaseEntity
}
