﻿using PontoFacil.Models;
using PontoFacil.Services;
using PontoFacil.Services.Interfaces;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;

namespace PontoFacil.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        #region Properties
        private DateTimeOffset _startDate;
        public DateTimeOffset StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private DateTimeOffset _endDate;
        public DateTimeOffset EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        private ObservableCollection<ClockIn> _history;
        public ObservableCollection<ClockIn> History
        {
            get { return _history; }
            set { SetProperty(ref _history, value); }
        }

        private string _accumulatedHours;
        public string AccumulatedHours
        {
            get { return _accumulatedHours; }
            set { SetProperty(ref _accumulatedHours, value); }
        }

        private string _dateValidationMessage;
        private ResourceLoader _loader;

        private IHistoryService _historyService;
        private ISettingsService _settingsService;

        #endregion

        #region Constructor
        public HistoryPageViewModel(IHistoryService historyService, ISettingsService settingsService)
        {
            InitializeCommands();

            _historyService = historyService;
            _settingsService = settingsService;
            _loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            // Set StartDate to yesterday by default
            StartDate = DateTime.Now.AddDays(-1);

            // Set EndDate to today by default
            EndDate = DateTime.Now;

            History = new ObservableCollection<ClockIn>();

            AccumulatedHours = settingsService.GetProfileAccumulatedHours();

            // Show monthly history by default
            ShowMonthlyHistory();
        }
        #endregion

        #region Methods
        private void InitializeCommands()
        {
            ShowMonthlyHistoryCommand = new DelegateCommand(ShowMonthlyHistory);
            ShowFreeHistoryCommand = new DelegateCommand(ShowFreeHistory);
            ClockInWaiverCommand = new DelegateCommand<ClockIn>(ClockInWaiver);
        }
        #endregion

        #region Commands
        public DelegateCommand ShowMonthlyHistoryCommand { get; private set; }
        public DelegateCommand ShowFreeHistoryCommand { get; private set; }
        public DelegateCommand<ClockIn> ClockInWaiverCommand { get; private set; }

        private void ShowMonthlyHistory()
        {
            History = new ObservableCollection<ClockIn>(_historyService.GetMonthlyHistory());
        }

        private async void ShowFreeHistory()
        {
            if (IsDateIntervalValid())
            {
                History = new ObservableCollection<ClockIn>(_historyService.GetFreeHistory(_startDate, _endDate));                
            }
            else
            {
                var dialog = new MessageDialog(_dateValidationMessage);
                await dialog.ShowAsync();
            }
        }

        private void ClockInWaiver(ClockIn clockIn)
        {
            TimeSpan hoursToWaive = clockIn.OvertimeHours.Negate();
            _settingsService.UpdateProfileAcumulatedHours(hoursToWaive);
            AccumulatedHours = _settingsService.GetProfileAccumulatedHours();

            _historyService.AllowWaiver(clockIn);
        }

        /// <summary>
        /// Check if the date interval is valid
        /// </summary>
        private bool IsDateIntervalValid()
        {
            bool isValid = true;

            if (_endDate > DateTime.Now)
            {
                _dateValidationMessage = _loader.GetString("EndDateLessThenCurrentDate");
                isValid = false;
            }
            else if(_endDate <= _startDate)
            {
                _dateValidationMessage = _loader.GetString("EndDateGreaterThenStartDate");
                isValid = false;
            }
            else if (_startDate >= DateTime.Now)
            {
                _dateValidationMessage = _loader.GetString("StartDateLessThenCurrentDate");
                isValid = false;
            }
            
            return isValid;
        }

        #endregion
    }
}