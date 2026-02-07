using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace InventoryBrother.Desktop.Converters;

public class EqualityToBrushConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is string paramString)
        {
            var parts = paramString.Split('|');
            if (parts.Length == 3)
            {
                var targetValue = parts[0];
                var trueBrushString = parts[1];
                var falseBrushString = parts[2];

                var valueString = value?.GetType().Name ?? value?.ToString() ?? string.Empty;

                if (valueString.Contains(targetValue))
                {
                    return Brush.Parse(trueBrushString);
                }
                return Brush.Parse(falseBrushString);
            }
        }
        return Brushes.Transparent;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
