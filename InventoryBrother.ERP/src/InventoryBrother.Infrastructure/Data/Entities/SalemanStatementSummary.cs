using System;
using System.Collections.Generic;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class SalemanStatementSummary
{
    public long SaleManId { get; set; }

    public string? SaleManName { get; set; }

    public double? TotalDebit { get; set; }

    public double? TotalCredit { get; set; }

    public double? Balance { get; set; }

    public string Statement { get; set; } = null!;

    public string NewTransaction { get; set; } = null!;
}
