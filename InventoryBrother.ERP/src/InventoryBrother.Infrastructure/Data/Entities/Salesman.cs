using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblSaleMan")]
public partial class Salesman : BaseEntity
{
    [Key]
    public long SalesmanId { get; set; }

    public string? SalesmanName { get; set; }

    public string? Address { get; set; }

    public string? MobileNo { get; set; }

    public string? Remarks { get; set; }

    public double? SalePercentage { get; set; }

    public string? Status { get; set; }
}
