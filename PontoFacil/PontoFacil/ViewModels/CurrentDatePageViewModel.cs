using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using Windows.UI.Xaml;

namespace PontoFacil.ViewModels
{
    public class CurrentDatePageViewModel : ViewModelBase
    {
        #region Properties
        private IClockInService _clockInService;

        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private DispatcherTimer _timer;
        #endregion

        public CurrentDatePageViewModel(IClockInService clockInService)
        {
            _clockInService = clockInService;
            InitializeCommands();

            InitializeClockInTime();
        }

        private void InitializeClockInTime()
        {
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

        private void RegisterTime()
        {
            _clockInService.Register(DateTime.Now);
        }

        public DelegateCommand RegisterTimeCommand { get; private set; }
    }
}
