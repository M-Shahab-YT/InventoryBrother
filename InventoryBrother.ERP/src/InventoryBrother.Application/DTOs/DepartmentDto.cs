using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryBrother.Application.DTOs;

public partial class DepartmentDto : ObservableObject
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _description;
}
