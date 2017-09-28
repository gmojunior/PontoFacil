using PontoFacil.Models;
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
        #region properties
        private DateTimeOffset startDate;
        public DateTimeOffset StartDate
        {
            get { return startDate; }
            set { SetProperty(ref startDate, value); }
        }

        private DateTimeOffset endDate;
        public DateTimeOffset EndDate
        {
            get { return endDate; }
            set { SetProperty(ref endDate, value); }
        }

        private ObservableCollection<ClockIn> history;
        public ObservableCollection<ClockIn> History
        {
            get { return history; }
            set { SetProperty(ref history, value); }
        }

        private string dateValidationMessage;

        // TO BE DELETED
        List<ClockIn> clockInMonthlyListToTest = new List<ClockIn>() {
                new ClockIn {Date = DateTimeOffset.Now.AddDays(1).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(2).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(3).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(4).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(5).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(6).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(8).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(9).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(10).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(11).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(12).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(13).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(14).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(15).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(16).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(17).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(18).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(19).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(20).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(21).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(22).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(23).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(24).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(25).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(26).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(27).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(28).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(29).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(30).Date, StartTime = "08:00", EndTime="17:30"}
            };
        List<ClockIn> clockInFreeListToTest = new List<ClockIn>() {
                new ClockIn {Date = DateTimeOffset.Now.AddDays(1).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(2).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(3).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(4).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(5).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(6).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(8).Date, StartTime = "08:00", EndTime="17:30"},
                new ClockIn {Date = DateTimeOffset.Now.AddDays(9).Date, StartTime = "08:00", EndTime="17:30"}
            };
        #endregion

        public HistoryPageViewModel()
        {
            InitializeCommands();

            // Set StartDate to yesterday by default
            StartDate = DateTime.Now.AddDays(-1);

            // Set EndDate to today by default
            EndDate = DateTime.Now;

            History = new ObservableCollection<ClockIn>();

            // Show monthly history by default
            ShowMonthlyHistory();
        }

        private void InitializeCommands()
        {
            ShowMonthlyHistoryCommand = new DelegateCommand(ShowMonthlyHistory);
            ShowFreeHistoryCommand = new DelegateCommand(ShowFreeHistory);
            ClockInWaiverCommand = new DelegateCommand<ClockIn>(ClockInWaiver);
            EditClockInCommand = new DelegateCommand<ClockIn>(EditClockIn);
        }

        #region Commands
        public DelegateCommand ShowMonthlyHistoryCommand { get; private set; }
        public DelegateCommand ShowFreeHistoryCommand { get; private set; }
        public DelegateCommand<ClockIn> ClockInWaiverCommand { get; private set; }
        public DelegateCommand<ClockIn> EditClockInCommand { get; private set; }

        private void ShowMonthlyHistory()
        {
            History.Clear();
            foreach (ClockIn clock in clockInMonthlyListToTest)
            {
                History.Add(clock);
            }
        }

        private async void ShowFreeHistory()
        {
            if (!IsDateIntervalValid())
            {
                var dialog = new MessageDialog(dateValidationMessage);
                await dialog.ShowAsync();
            }
            else
            {
                History.Clear();
                foreach (ClockIn clock in clockInFreeListToTest)
                {
                    History.Add(clock);
                }
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

            if(endDate > DateTime.Now)
            {
                dateValidationMessage = "The End Date must be less than the current date.";
                isValid = false;
            }
            else if(endDate <= startDate)
            {
                dateValidationMessage = "The End Date must be greater than the Start Date.";
                isValid = false;
            }
            else if (startDate >= DateTime.Now)
            {
                dateValidationMessage = "The Start Date must be less than the current date.";
                isValid = false;
            }
            
            return isValid;
        }

        #endregion
    }
}
