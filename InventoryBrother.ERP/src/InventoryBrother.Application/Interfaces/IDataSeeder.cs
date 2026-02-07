using System.Threading.Tasks;

namespace InventoryBrother.Application.Interfaces;

public interface IDataSeeder
{
    Task SeedAsync();
}
