using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryBrother.Infrastructure.Data;

public class InventoryBrotherDbContextFactory : IDesignTimeDbContextFactory<InventoryBrotherDbContext>
{
    public InventoryBrotherDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryBrotherDbContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=InventoryBrother;Integrated Security=True;TrustServerCertificate=True");

        return new InventoryBrotherDbContext(optionsBuilder.Options);
    }
}
