using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Lookups;
using InventoryBrother.Application.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBrother.Desktop.ViewModels;

public partial class LookupViewModel : ViewModelBase
{
    private readonly ILookupService _lookupService;

    [ObservableProperty]
    private string _selectedType = "Category";

    [ObservableProperty]
    private ObservableCollection<LookupDto> _lookups = new();

    [ObservableProperty]
    private LookupDto? _selectedLookup;

    [ObservableProperty]
    private string _newItemName = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    public ObservableCollection<string> LookupTypes { get; } = new() 
    { 
        "Category", "Unit", "Brand", "Location" 
    };

    public LookupViewModel(ILookupService lookupService)
    {
        _lookupService = lookupService;
        LoadLookupsCommand.Execute(null);
    }

    partial void OnSelectedTypeChanged(string value)
    {
        LoadLookupsCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadLookups()
    {
        IsBusy = true;
        try
        {
            var result = await _lookupService.GetLookupsAsync(SelectedType);
            Lookups = new ObservableCollection<LookupDto>(result);
        }
        catch (Exception ex)
        {
            // Handle error (maybe add ErrorMessage to ViewModelBase)
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddLookup()
    {
        if (string.IsNullOrWhiteSpace(NewItemName)) return;

        IsBusy = true;
        try
        {
            await _lookupService.CreateLookupAsync(SelectedType, new CreateLookupDto { Name = NewItemName });
            NewItemName = string.Empty;
            await LoadLookups();
        }
        catch (Exception) { }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    private async Task DeleteLookup(LookupDto dto)
    {
        if (dto == null) return;
        
        IsBusy = true;
        try
        {
            await _lookupService.DeleteLookupAsync(SelectedType, dto.Id);
            await LoadLookups();
        }
        catch (Exception) { }
        finally { IsBusy = false; }
    }
}
