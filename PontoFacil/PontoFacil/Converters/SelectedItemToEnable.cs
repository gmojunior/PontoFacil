using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PontoFacil.Converters
{
    class SelectedItemToEnable : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string test)
        {
            return value != null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string test)
        {
            throw new NotImplementedException();
        }
    }
}
