using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
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

        private string dateValidationMessage;
        #endregion

        public HistoryPageViewModel()
        {
            InitializeCommands();

            // Set StartDate to yesterday by default
            StartDate = DateTime.Now.AddDays(-1);

            // Set EndDate to today by default
            EndDate = DateTime.Now;
        }

        private void InitializeCommands()
        {
            ShowFreeHistoryCommand = new DelegateCommand(ShowFreeHistory);
        }

        #region Commands
        public DelegateCommand ShowFreeHistoryCommand { get; private set; }

        private async void ShowFreeHistory()
        {
            if (!IsDateIntervalValid())
            {
                var dialog = new MessageDialog(dateValidationMessage);
                await dialog.ShowAsync();
            }
            else
            {

            }
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
