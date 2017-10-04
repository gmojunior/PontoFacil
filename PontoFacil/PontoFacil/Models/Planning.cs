using Prism.Mvvm;
using System;

namespace PontoFacil.Models
{
    public class Planning : BindableBase
    {
        #region Properties
        private TimeSpan _hoursToAdjustValue;
        public TimeSpan HoursToAdjustValue
        {
            get { return _hoursToAdjustValue; }
            set { SetProperty(ref _hoursToAdjustValue, value); }
        }

        private int _numberOfDaysValue;
        public int NumberOfDaysValue
        {
            get { return _numberOfDaysValue; }
            set { SetProperty(ref _numberOfDaysValue, value); }
        }

        private System.Nullable<DateTimeOffset> _startDayValue;
        public System.Nullable<DateTimeOffset> StartDayValue
        {
            get { return _startDayValue; }
            set { SetProperty(ref _startDayValue, value); }
        }
        #endregion
    }
}
