using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace InventoryBrother.Desktop.Converters;

public class StockColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is decimal stock)
        {
            if (stock <= 0) return Brushes.Red;
            if (stock < 10) return Brushes.Orange;
            return Brushes.Green;
        }
        return Brushes.Black;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
