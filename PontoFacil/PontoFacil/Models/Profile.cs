using PontoFacil.Services.Interfaces;
using Prism.Mvvm;
using System;
using System.Text;
using Windows.ApplicationModel.Resources;

namespace PontoFacil.Models
{
    public class Profile : BindableBase, IValidator
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private TimeSpan _entryHour;
        public TimeSpan EntryHour
        {
            get { return _entryHour; }
            set { SetProperty(ref _entryHour, value); }
        }

        private byte _lunchTime;
        public byte LunchTime
        {
            get { return _lunchTime; }
            set { SetProperty(ref _lunchTime, value); }
        }

        private TimeSpan _exitHour;
        public TimeSpan ExitHour
        {
            get { return _exitHour; }
            set { SetProperty(ref _exitHour, value); }
        }

        private string _accumulatedHours;
        public string AccumulatedHours
        {
            get { return _accumulatedHours; }
            set { SetProperty(ref _accumulatedHours, value); }
        }

        private bool? _notify;
        public bool? Notify
        {
            get { return _notify; }
            set { SetProperty(ref _notify, value); }
        }

        private string _notifyTime;
        public string NotifyTime
        {
            get { return _notifyTime; }
            set { SetProperty(ref _notifyTime, value); }
        }

        public StringBuilder MessagesValidator { get; private set; }

        #endregion

        #region Constants
        private const string MESSAGE_NAME_ISNOT_EMPTY = "NameIsNotEmpty";
        private const string MESSAGE_ENTRY_HOUR_SAME_EXIT = "EntryHourSameExit";
        private const string MESSAGE_LUNCH_TIME_ISNOT_EMPTY = "LunchTimeIsNotEmpty";
        private const string MESSAGE_ACCUMULATEDHOURS_ISNOT_EMPTY = "AccumulatedHoursIsNotEmpty";
        private const string MESSAGE_NOTIFY_ISNOT_EMPTY = "NotifyNotEmpty";
        private const string MESSAGE_NOTIFY_TIME_ISNOT_EMPTY = "NotifyTimeNotEmpty";
        #endregion

        #region Methods
        public bool IsValid()
        {
            ValidateProperties();

            return MessagesValidator.Length == 0;
        }

        private void ValidateProperties()
        {
            var loader = new ResourceLoader();
            MessagesValidator = new StringBuilder();
            string message;

            if (string.IsNullOrWhiteSpace(Name))
            {
                message = loader.GetString(MESSAGE_NAME_ISNOT_EMPTY);
                MessagesValidator.AppendLine(message);
            }

            if (EntryHour == ExitHour)
            {
                message = loader.GetString(MESSAGE_ENTRY_HOUR_SAME_EXIT);
                MessagesValidator.AppendLine(message);
            }

            if (LunchTime < 1)
            {
                message = loader.GetString(MESSAGE_LUNCH_TIME_ISNOT_EMPTY);
                MessagesValidator.AppendLine(message);
            }
                
            DateTime date;
            if (!DateTime.TryParse(AccumulatedHours, out date))
            {
                message = loader.GetString(MESSAGE_ACCUMULATEDHOURS_ISNOT_EMPTY);
                MessagesValidator.AppendLine(message);
            }

            if (Notify == null)
            {
                message = loader.GetString(MESSAGE_NOTIFY_ISNOT_EMPTY);
                MessagesValidator.AppendLine(message);
            }

            if (Notify == true && !string.IsNullOrWhiteSpace(NotifyTime) && int.Parse(NotifyTime) < 1)
            {
                message = loader.GetString(MESSAGE_NOTIFY_TIME_ISNOT_EMPTY);
                MessagesValidator.AppendLine(message);
            }
        }
        #endregion
    }
}