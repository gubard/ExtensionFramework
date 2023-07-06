using System.Globalization;
using Avalonia.Data.Converters;

namespace ExtensionFramework.AvaloniaUi.Converters;

public class ObjectToVisibleValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return false;
        }

        return true;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}