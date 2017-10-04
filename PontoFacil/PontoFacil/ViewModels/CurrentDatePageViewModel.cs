using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using Prism.Commands;
using System;
using Windows.UI.Xaml;

namespace PontoFacil.ViewModels
{
    public class CurrentDatePageViewModel : StateViewModelBase
    {
        #region Properties
        private IClockInService _clockInService;
        private ISettingsService _settingsService;
        public DelegateCommand RegisterTimeCommand { get; private set; }
        private DispatcherTimer _timer;

        private string _dayOfWeekDayMonthYear;
        public string DayOfWeekDayMonthYear
        {
            get { return _dayOfWeekDayMonthYear; }
            set { SetProperty(ref _dayOfWeekDayMonthYear, value); }
        }

        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private string _startTime;
        public string StartTime
        {
            get { return this._startTime; }
            set { SetProperty(ref _startTime, value); }
        }

        private string _endTime;
        public string EndTime
        {
            get { return this._endTime; }
            set { SetProperty(ref _endTime, value); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private ClockIn _currentclockIn;
        public ClockIn CurrentClockIn
        {
            get { return _currentclockIn; }
            set { SetProperty(ref _currentclockIn, value); }
        }
        #endregion

        #region Constructor
        public CurrentDatePageViewModel(IClockInService clockInService, ISettingsService settingsService)
        {
            _clockInService = clockInService;
            _settingsService = settingsService;

            ClockIn clockIn = _clockInService.getClockInById(DateTime.Now.Date);
            SetStartEndTime(clockIn);

            initializeProperties();
            InitializeCommands();
            InitializeClockInTime();
        }
        #endregion

        #region Methods
        private void initializeProperties()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            var linkPreposition = loader.GetString("LinkPreposition");
            DayOfWeekDayMonthYear = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy").Replace("{0}", linkPreposition);

            Profile profile = _settingsService.GetProfile();
            UserName = profile.Name;
        }

        private void InitializeClockInTime()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InitializeCommands()
        {
            RegisterTimeCommand = new DelegateCommand(RegisterTime);
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            ClockIn clockIn = _clockInService.getClockInById(DateTime.Now.Date);
            SetButtonState(clockIn);
        }

        private void RegisterTime()
        {
            CurrentClockIn = _clockInService.Register(DateTime.Now);

            SetStartEndTime(CurrentClockIn);

            SetButtonState(CurrentClockIn);
        }

        private void SetStartEndTime(ClockIn clockIn)
        {
            if (clockIn != null)
            {
                StartTime = clockIn.Start.ToString("HH:mm:ss");

                if (!clockIn.IsOpen())
                {
                    EndTime = clockIn.End.ToString("HH:mm:ss");
                }
            }
        }

        private void SetButtonState(ClockIn clockIn)
        {

            if (clockIn != null)
            {
                if (clockIn.IsOpen())
                {
                    GoToState(REGISTER_OUT_STATE);
                }
                else
                {
                    GoToState(REGISTER_DISABLED);
                }
            }
        }
        #endregion        
    }
}
