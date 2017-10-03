using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace PontoFacil.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception)
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return ((Visibility)value) == Visibility.Visible;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
