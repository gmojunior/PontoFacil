using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PontoFacil.Converters
{
    class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string time = "00:00:00";
            try
            {
                if (value != null)
                {
                    time = (TimeSpan)value < TimeSpan.Zero ? "-" + ((TimeSpan)value).ToString(@"hh\:mm\:ss") : ((TimeSpan)value).ToString(@"hh\:mm\:ss");
                }

                return time;
            }
            catch (Exception)
            {
                return time;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
