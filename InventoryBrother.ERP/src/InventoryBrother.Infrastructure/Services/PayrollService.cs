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

public class PayrollService : IPayrollService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public PayrollService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PayrollDto>> GeneratePayrollForMonthAsync(int month, int year)
    {
        // 1. Check if payroll already exists for this month/year to avoid duplicates
        var existing = await _dbContext.Payrolls
            .Include(p => p.Employee)
            .Where(p => p.Month == month && p.Year == year)
            .ToListAsync();

        if (existing.Any())
        {
            // Return existing records
            return existing.Select(MapToDto).ToList();
        }

        // 2. Generate new payroll for all active employees
        var employees = await _dbContext.Employees
            .Where(e => e.IsActive)
            .Include(e => e.Department)
            .ToListAsync();

        var newPayrolls = new List<Payroll>();

        foreach (var emp in employees)
        {
            var p = new Payroll
            {
                EmployeeId = emp.Id,
                Month = month,
                Year = year,
                BasicSalary = emp.BasicSalary ?? 0,
                Allowance = 0, // Placeholder for future logic
                Deduction = 0, // Placeholder
                TotalSalary = emp.BasicSalary ?? 0, // Net = Basic + 0 - 0
                Date = DateTime.Now,
                CreatedBy = "System", // Or current user
                CreatedAt = DateTime.Now
                // Status? We don't have a status column in entity, assume unpaid if not handled elsewhere?
                // Actually entity doesn't have status, maybe we can use Remarks or just rely on existence
            };
            newPayrolls.Add(p);
        }

        _dbContext.Payrolls.AddRange(newPayrolls);
        await _dbContext.SaveChangesAsync();

        // Re-fetch to include any db-generated IDs if needed, or just map what we have
        // But for cleaner return, let's map the entities we just saved
        // We need to attach Employee navigation for mapping
        foreach (var p in newPayrolls)
        {
             p.Employee = employees.First(e => e.Id == p.EmployeeId);
        }

        return newPayrolls.Select(MapToDto).ToList();
    }

    public async Task<List<PayrollDto>> GetPayrollHistoryAsync(int month, int year)
    {
        var list = await _dbContext.Payrolls
            .Include(p => p.Employee)
            .ThenInclude(e => e.Department)
            .Where(p => p.Month == month && p.Year == year)
            .OrderBy(p => p.Employee.Name)
            .ToListAsync();

        return list.Select(MapToDto).ToList();
    }

    public async Task PayEmployeeAsync(long payrollId)
    {
        // Entity doesn't have "IsPaid" status yet. 
        // For now, we just acknowledge the request. 
        // In a real system, we'd update a status column or create a financial transaction.
        await Task.CompletedTask;
    }

    public async Task DeletePayrollAsync(long payrollId)
    {
        var entity = await _dbContext.Payrolls.FindAsync(payrollId);
        if (entity != null)
        {
            _dbContext.Payrolls.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    private static PayrollDto MapToDto(Payroll p)
    {
        return new PayrollDto
        {
            Id = p.Sno,
            EmployeeId = p.EmployeeId ?? 0,
            EmployeeName = p.Employee?.Name ?? "Unknown",
            Designation = p.Employee?.Designation,
            Month = p.Month ?? 0,
            Year = p.Year ?? 0,
            BasicSalary = p.BasicSalary,
            Allowance = p.Allowance,
            Deduction = p.Deduction,
            NetSalary = p.TotalSalary,
            PaymentDate = p.Date,
            Status = "Generated" // Placeholder
        };
    }
}
