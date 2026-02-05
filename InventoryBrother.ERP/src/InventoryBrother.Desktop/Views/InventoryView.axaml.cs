using Avalonia.Controls;
using Avalonia.Input;
using InventoryBrother.Desktop.ViewModels;

namespace InventoryBrother.Desktop.Views;

public partial class InventoryView : UserControl
{
    public InventoryView()
    {
        InitializeComponent();
    }

    private void Search_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (DataContext is InventoryViewModel vm)
            {
                vm.LoadProductsCommand.Execute(null);
            }
        }
    }
}
