using System;
using Windows.UI.Xaml.Data;

namespace PontoFacil.Converters
{
    class LunchTimeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (IsOneHourRadioButton(parameter))
                return ShouldCheckOneHourRadioButton(value);
            else if (IsTwoHoursRadioButton(parameter))
                return ShouldCheckTwoHoursRadioButton(value);
            else return null;
        }

        private static bool ShouldCheckTwoHoursRadioButton(object value)
        {
            return ((byte)value) == TWO_HOURS;
        }

        private static bool ShouldCheckOneHourRadioButton(object value)
        {
            return ((byte)value) == ONE_HOUR;
        }

        private static bool IsTwoHoursRadioButton(object parameter)
        {
            return ((string)parameter).Equals("TwoHours");
        }

        private static bool IsOneHourRadioButton(object parameter)
        {
            return ((string)parameter).Equals("OneHour");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (IsOneHourRadioButton(parameter))
                return ONE_HOUR;
            else if (IsTwoHoursRadioButton(parameter))
                return TWO_HOURS;
            else return null;
        }

        private const byte TWO_HOURS = 2;

        private const byte ONE_HOUR = 1;
    }
}
