using Prism.Mvvm;
using System;
using Prism.Mvvm;

namespace PontoFacil.Models
{
    public class Profile : BindableBase
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

        private string _lunchTime;
        public string LunchTime
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

        private TimeSpan initialBalance;
        public TimeSpan InitialBalance
        {
            get { return initialBalance; }
            set { SetProperty(ref initialBalance, value); }
        }

        private bool? _notify;
        public bool? Notify
        {
            get { return _notify; }
            set { SetProperty(ref _notify, value); }
        }

        private TimeSpan _notifyTime;
        public TimeSpan NotifyTime
        {
            get { return _notifyTime; }
            set { SetProperty(ref _notifyTime, value); }
        }
        #endregion
    }
}