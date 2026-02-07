using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace InventoryBrother.Desktop.Views;

public partial class EmployeeView : UserControl
{
    public EmployeeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
