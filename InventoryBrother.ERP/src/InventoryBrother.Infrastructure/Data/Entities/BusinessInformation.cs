using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;


public partial class BusinessInformation : BaseEntity
{
    [Key]
    public int BusinessId { get; set; }

    public string? BusinessName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
