using Prism.Windows.Mvvm;
using System;
using Windows.System;
using Windows.UI.Xaml.Input;

namespace PontoFacil.ViewModels
{
    public class PlanningPageViewModel : ViewModelBase
    {
        #region Properties
        private DateTime _accumulatedHoursValue;
        public DateTime AccumulatedHoursValue {
            get => _accumulatedHoursValue;
            set => SetProperty(ref _accumulatedHoursValue, value);
        }

        private DateTime _hoursToAdjustValue;
        public DateTime HoursToAdjustValue
        {
            get => _hoursToAdjustValue;
            set => SetProperty(ref _hoursToAdjustValue, value);
        }

        private int _numberOfDaysValue;
        public int NumberOfDaysValue
        {
            get => _numberOfDaysValue;
            set => SetProperty(ref _numberOfDaysValue, value);
        }

        private DateTime _startDayValue;
        public DateTime StartDayValue {
            get => _startDayValue.Date;
            set => SetProperty(ref _startDayValue, value);
        }
        #endregion

        #region Construcutor
        public PlanningPageViewModel()
        {
            _accumulatedHoursValue = DateTime.MinValue;
            _hoursToAdjustValue = DateTime.MinValue;
            _numberOfDaysValue = 0;
            _startDayValue = DateTime.Now;
        }
        #endregion

        #region Method
        public void NumberTypeCheck(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = ((uint)e.Key >= (uint)VirtualKey.Number0 && (uint)e.Key >= (uint)VirtualKey.Number9);
        }
        #endregion
    }
}
