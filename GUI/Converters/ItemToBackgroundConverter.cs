using System;
using System.Globalization;
using System.Windows.Data;

namespace GUI.Converters;

public class ItemToBackgroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null || string.IsNullOrEmpty(value.ToString()) ? "Images/Backgrounds/Itemslot_Empty.png" : "Images/Backgrounds/Itemslot_Full.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}