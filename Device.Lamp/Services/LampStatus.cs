using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Device.Lamp.Services;

public class LampStatus : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            var hexColor = (bool)value ? "#FFF6B7" : "#D3D3D3";
            var brush = new BrushConverter().ConvertFrom(hexColor) as SolidColorBrush;
            return brush ?? ((bool)value ? Brushes.Gold : Brushes.Gray); 
        }
        catch
        {
            return (bool)value ? Brushes.Gold : Brushes.Gray;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
