using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBrother.Application.DTOs;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public EmployeeService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        return await _dbContext.Employees
            .Include(e => e.Department)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Designation = e.Designation,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department != null ? e.Department.Name : null,
                Phone = e.Phone,
                Email = e.Email,
                BasicSalary = e.BasicSalary,
                JoiningDate = e.JoiningDate,
                IsActive = e.IsActive
            })
            .ToListAsync();
    }

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
    {
        var e = await _dbContext.Employees
            .Include(x => x.Department)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (e == null) return null;

        return new EmployeeDto
        {
            Id = e.Id,
            Name = e.Name,
            Designation = e.Designation,
            DepartmentId = e.DepartmentId,
            DepartmentName = e.Department?.Name,
            Phone = e.Phone,
            Email = e.Email,
            BasicSalary = e.BasicSalary,
            JoiningDate = e.JoiningDate,
            IsActive = e.IsActive
        };
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto)
    {
        var entity = new Employee
        {
            Name = dto.Name,
            Designation = dto.Designation,
            DepartmentId = dto.DepartmentId,
            Phone = dto.Phone,
            Email = dto.Email,
            BasicSalary = dto.BasicSalary,
            JoiningDate = dto.JoiningDate,
            IsActive = dto.IsActive ?? true
        };

        _dbContext.Employees.Add(entity);
        await _dbContext.SaveChangesAsync();

        dto.Id = entity.Id;
        return dto;
    }

    public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto dto)
    {
        var entity = await _dbContext.Employees.FindAsync(dto.Id);
        if (entity == null) throw new Exception("Employee not found");

        entity.Name = dto.Name;
        entity.Designation = dto.Designation;
        entity.DepartmentId = dto.DepartmentId;
        entity.Phone = dto.Phone;
        entity.Email = dto.Email;
        entity.BasicSalary = dto.BasicSalary;
        entity.JoiningDate = dto.JoiningDate;
        entity.IsActive = dto.IsActive ?? true;

        await _dbContext.SaveChangesAsync();

        if (dto.DepartmentId.HasValue)
        {
             var dep = await _dbContext.Departments.FindAsync(dto.DepartmentId.Value);
             dto.DepartmentName = dep?.Name;
        }

        return dto;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var entity = await _dbContext.Employees.FindAsync(id);
        if (entity != null)
        {
            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
    {
        return await _dbContext.Departments
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            })
            .ToListAsync();
    }

    public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto dto)
    {
        var entity = new Department
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _dbContext.Departments.Add(entity);
        await _dbContext.SaveChangesAsync();

        dto.Id = entity.Id;
        return dto;
    }
}
