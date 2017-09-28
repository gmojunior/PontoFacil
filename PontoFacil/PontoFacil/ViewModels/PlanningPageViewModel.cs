using PontoFacil.Services;
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
            get { return _accumulatedHoursValue; }
            set { SetProperty(ref _accumulatedHoursValue, value); }
        }

        private DateTime _hoursToAdjustValue;
        public DateTime HoursToAdjustValue
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

        private DateTime _startDayValue;
        public DateTime StartDayValue {
            get { return _startDayValue.Date; }
            set { SetProperty(ref _startDayValue, value); }
        }

        private IPlanningService _planningService;
        #endregion

        #region Construcutor
        public PlanningPageViewModel(IPlanningService planningService)
        {
            _planningService = planningService;
        }
        #endregion
    }
}
