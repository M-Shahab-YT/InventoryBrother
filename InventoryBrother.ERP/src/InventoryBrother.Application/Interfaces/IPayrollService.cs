using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryBrother.Application.DTOs;

namespace InventoryBrother.Application.Interfaces;

public interface IPayrollService
{
    Task<List<PayrollDto>> GeneratePayrollForMonthAsync(int month, int year);
    Task<List<PayrollDto>> GetPayrollHistoryAsync(int month, int year);
    Task PayEmployeeAsync(long payrollId);
    Task DeletePayrollAsync(long payrollId);
}
