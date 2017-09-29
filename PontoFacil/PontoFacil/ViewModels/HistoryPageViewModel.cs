using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

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

        private string _dateValidationMessage;

        private IHistoryService _historyService;

        #endregion

        #region Constructor
        public HistoryPageViewModel(IHistoryService historyService)
        {
            InitializeCommands();

            _historyService = historyService;
            // Set StartDate to yesterday by default
            StartDate = DateTime.Now.AddDays(-1);

            // Set EndDate to today by default
            EndDate = DateTime.Now;

            History = new ObservableCollection<ClockIn>();

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
            EditClockInCommand = new DelegateCommand<ClockIn>(EditClockIn);
        }
        #endregion

        #region Commands
        public DelegateCommand ShowMonthlyHistoryCommand { get; private set; }
        public DelegateCommand ShowFreeHistoryCommand { get; private set; }
        public DelegateCommand<ClockIn> ClockInWaiverCommand { get; private set; }
        public DelegateCommand<ClockIn> EditClockInCommand { get; private set; }

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

        }

        private void EditClockIn(ClockIn clockIn)
        {

        }

        /// <summary>
        /// Check if the date interval is valid
        /// </summary>
        private bool IsDateIntervalValid()
        {
            bool isValid = true;

            if(_endDate > DateTime.Now)
            {
                _dateValidationMessage = "The End Date must be less than the current date.";
                isValid = false;
            }
            else if(_endDate <= _startDate)
            {
                _dateValidationMessage = "The End Date must be greater than the Start Date.";
                isValid = false;
            }
            else if (_startDate >= DateTime.Now)
            {
                _dateValidationMessage = "The Start Date must be less than the current date.";
                isValid = false;
            }
            
            return isValid;
        }

        #endregion
    }
}