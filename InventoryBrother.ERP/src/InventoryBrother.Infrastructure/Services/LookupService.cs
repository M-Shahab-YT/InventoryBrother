using InventoryBrother.Application.DTOs.Lookups;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBrother.Infrastructure.Services;

public class LookupService : ILookupService
{
    private readonly InventoryBrotherDbContext _dbContext;

    public LookupService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<LookupDto>> GetLookupsAsync(string type)
    {
        return type.ToLower() switch
        {
            "category" => await _dbContext.ProductCategories
                .Select(x => new LookupDto { Id = x.CategoryCode, Name = x.CategoryName ?? string.Empty }).ToListAsync(),
            "unit" => await _dbContext.UnitOfMeasurements
                .Select(x => new LookupDto { Id = x.UnitId, Name = x.UnitName ?? string.Empty }).ToListAsync(),
            "brand" => await _dbContext.Brands
                .Select(x => new LookupDto { Id = x.BrandId, Name = x.BrandName ?? string.Empty }).ToListAsync(),
            "location" => await _dbContext.ProductLocations
                .Select(x => new LookupDto { Id = x.LocationId, Name = x.LocationName ?? string.Empty }).ToListAsync(),
            "department" => await _dbContext.Departments
                .Select(x => new LookupDto { Id = x.Id, Name = x.Name ?? string.Empty }).ToListAsync(),
            "color" => await _dbContext.Colors
                .Select(x => new LookupDto { Id = x.ColorId, Name = x.ColorName ?? string.Empty }).ToListAsync(),
            "size" => await _dbContext.Sizes
                .Select(x => new LookupDto { Id = x.SizeId, Name = x.SizeName ?? string.Empty }).ToListAsync(),
            "manufacturer" => await _dbContext.Manufacturers
                .Select(x => new LookupDto { Id = x.ManufacturerId, Name = x.ManufacturerName ?? string.Empty }).ToListAsync(),
            _ => throw new ArgumentException($"Invalid lookup type: {type}")
        };
    }

    public async Task<LookupDto> CreateLookupAsync(string type, CreateLookupDto dto)
    {
        switch (type.ToLower())
        {
            case "category":
                var cat = new ProductCategory { CategoryName = dto.Name, StoreId = 1 };
                _dbContext.ProductCategories.Add(cat);
                await _dbContext.SaveChangesAsync();
                return new LookupDto { Id = cat.CategoryCode, Name = cat.CategoryName };
            case "unit":
                var unit = new UnitOfMeasurement { UnitName = dto.Name, StoreId = 1 };
                _dbContext.UnitOfMeasurements.Add(unit);
                await _dbContext.SaveChangesAsync();
                return new LookupDto { Id = unit.UnitId, Name = unit.UnitName };
            case "brand":
                var brand = new Brand { BrandName = dto.Name, StoreId = 1 };
                _dbContext.Brands.Add(brand);
                await _dbContext.SaveChangesAsync();
                return new LookupDto { Id = brand.BrandId, Name = brand.BrandName };
            case "location":
                var loc = new ProductLocation { LocationName = dto.Name, StoreId = 1 };
                _dbContext.ProductLocations.Add(loc);
                await _dbContext.SaveChangesAsync();
                return new LookupDto { Id = loc.LocationId, Name = loc.LocationName };
            case "department":
                var dept = new Department { Name = dto.Name, StoreId = 1 };
                _dbContext.Departments.Add(dept);
                await _dbContext.SaveChangesAsync();
                return new LookupDto { Id = dept.Id, Name = dept.Name };
            default:
                throw new ArgumentException($"Creation not implemented for type: {type}");
        }
    }

    public async Task UpdateLookupAsync(string type, LookupDto dto)
    {
         switch (type.ToLower())
        {
            case "category":
                var cat = await _dbContext.ProductCategories.FindAsync((int)dto.Id);
                if (cat != null) { cat.CategoryName = dto.Name; await _dbContext.SaveChangesAsync(); }
                break;
            case "unit":
                var unit = await _dbContext.UnitOfMeasurements.FindAsync((int)dto.Id);
                if (unit != null) { unit.UnitName = dto.Name; await _dbContext.SaveChangesAsync(); }
                break;
            case "brand":
                var brand = await _dbContext.Brands.FindAsync((int)dto.Id);
                if (brand != null) { brand.BrandName = dto.Name; await _dbContext.SaveChangesAsync(); }
                break;
            case "department":
                var dept = await _dbContext.Departments.FindAsync((int)dto.Id);
                if (dept != null) { dept.Name = dto.Name; await _dbContext.SaveChangesAsync(); }
                break;
        }
    }

    public async Task DeleteLookupAsync(string type, long id)
    {
         switch (type.ToLower())
        {
            case "category":
                var cat = await _dbContext.ProductCategories.FindAsync((int)id);
                if (cat != null) { _dbContext.ProductCategories.Remove(cat); await _dbContext.SaveChangesAsync(); }
                break;
            case "unit":
                var unit = await _dbContext.UnitOfMeasurements.FindAsync((int)id);
                if (unit != null) { _dbContext.UnitOfMeasurements.Remove(unit); await _dbContext.SaveChangesAsync(); }
                break;
            case "department":
                var dept = await _dbContext.Departments.FindAsync((int)id);
                if (dept != null) { _dbContext.Departments.Remove(dept); await _dbContext.SaveChangesAsync(); }
                break;
        }
    }
}
