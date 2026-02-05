using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryBrother.Desktop.ViewModels;

/// <summary>
/// Base class for all ViewModels using CommunityToolkit.Mvvm
/// </summary>
public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;
    
    [ObservableProperty]
    private string _busyMessage = string.Empty;
    
    [ObservableProperty]
    private string? _errorMessage;
    
    protected void SetBusy(string message = "Loading...")
    {
        IsBusy = true;
        BusyMessage = message;
        ErrorMessage = null;
    }
    
    protected void ClearBusy()
    {
        IsBusy = false;
        BusyMessage = string.Empty;
    }
    
    protected void SetError(string message)
    {
        ClearBusy();
        ErrorMessage = message;
    }
}
