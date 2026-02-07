using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryBrother.Application.Interfaces;

public interface IExportService
{
    Task<byte[]> ExportToExcelAsync<T>(IEnumerable<T> data, string fileName);
    Task<byte[]> ExportToPdfAsync<T>(IEnumerable<T> data, string title);
}
