﻿using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using Windows.UI.Xaml;

namespace PontoFacil.ViewModels
{
    public class CurrentDatePageViewModel : StateViewModelBase
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

        #endregion

        public CurrentDatePageViewModel(IClockInService clockInService)
        {
            _clockInService = clockInService;

            ClockIn clockIn = _clockInService.getClockInById(DateTime.Now.Date);
            SetStartEndTime(clockIn);

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

        protected override void OnLoaded()
        {
            base.OnLoaded();

            ClockIn clockIn = _clockInService.getClockInById(DateTime.Now.Date);
            SetButtonState(clockIn);
        }

        private void RegisterTime()
        {
            _clockInService.Register(DateTime.Now);

            ClockIn clockIn = _clockInService.getClockInById(DateTime.Now.Date);

            SetStartEndTime(clockIn);

            SetButtonState(clockIn);
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

        public DelegateCommand RegisterTimeCommand { get; private set; }
    }
}
