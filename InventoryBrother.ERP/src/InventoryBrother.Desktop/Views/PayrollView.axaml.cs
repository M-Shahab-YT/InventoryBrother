using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace InventoryBrother.Desktop.Views;

public partial class PayrollView : UserControl
{
    public PayrollView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
