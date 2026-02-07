using System.Threading.Tasks;
using InventoryBrother.Application.DTOs;

namespace InventoryBrother.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardMetricsDto> GetKeyMetricsAsync();
}
