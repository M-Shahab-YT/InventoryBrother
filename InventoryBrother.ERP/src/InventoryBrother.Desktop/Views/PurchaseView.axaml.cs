using Avalonia.Controls;
using Avalonia.Input;
using InventoryBrother.Desktop.ViewModels;

namespace InventoryBrother.Desktop.Views;

public partial class PurchaseView : UserControl
{
    public PurchaseView()
    {
        InitializeComponent();
    }

    private void SearchBar_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (DataContext is PurchaseViewModel vm)
            {
                vm.AddProductCommand.Execute(null);
            }
        }
    }
}
