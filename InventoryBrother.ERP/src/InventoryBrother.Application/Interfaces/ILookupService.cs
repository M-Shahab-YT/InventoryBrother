using InventoryBrother.Application.DTOs.Lookups;

namespace InventoryBrother.Application.Interfaces;

public interface ILookupService
{
    Task<List<LookupDto>> GetLookupsAsync(string type);
    Task<LookupDto> CreateLookupAsync(string type, CreateLookupDto dto);
    Task UpdateLookupAsync(string type, LookupDto dto);
    Task DeleteLookupAsync(string type, long id);
}
