namespace InventoryBrother.Application.DTOs.Lookups;

public class LookupDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CreateLookupDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
