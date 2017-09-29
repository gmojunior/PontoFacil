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

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set { SetProperty(ref currentTime, value); }
        }

        DispatcherTimer Timer = new DispatcherTimer();
        #endregion

        public CurrentDatePageViewModel(IClockInService clockInService)
        {
            _clockInService = clockInService;
            InitializeCommands();

            InitializeClockInTime();
        }

        private void InitializeClockInTime()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
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
