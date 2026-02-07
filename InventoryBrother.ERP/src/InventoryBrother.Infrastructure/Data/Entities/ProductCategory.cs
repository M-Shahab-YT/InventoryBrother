using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class ProductCategory : BaseEntity
{
    [Key]
    public int CategoryCode { get; set; }

    public string? CategoryName { get; set; }

    public int? GroupId { get; set; }
}
