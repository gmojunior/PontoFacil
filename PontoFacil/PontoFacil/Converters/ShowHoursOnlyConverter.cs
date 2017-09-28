using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PontoFacil.Converters
{
    public class ShowHoursOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Parse((string) value);
        }
    }
}
