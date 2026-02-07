using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryBrother.Application.DTOs;

namespace InventoryBrother.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee);
    Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employee);
    Task DeleteEmployeeAsync(int id);

    Task<List<DepartmentDto>> GetAllDepartmentsAsync();
    Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto department);
}
