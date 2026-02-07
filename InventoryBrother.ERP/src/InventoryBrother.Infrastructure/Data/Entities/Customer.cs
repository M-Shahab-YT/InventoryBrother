using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class Customer : BaseEntity
{
    [Key]
    public string CustomerId { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? CustomerMobile { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerType { get; set; }

    public string? ContactPerson { get; set; }

    public string? Status { get; set; }
    public string? AreaCode { get; set; }

    // StoreId and Audit fields are in BaseEntity
}
