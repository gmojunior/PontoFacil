using Prism.Mvvm;
using System;

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

        private TimeSpan _entryTime;
        public TimeSpan EntryTime
        {
            get { return _entryTime; }
            set { SetProperty(ref _entryTime, value); }
        }

        private string _lunchTime;
        public string LunchTime
        {
            get { return _lunchTime; }
            set { SetProperty(ref _lunchTime, value); }
        }

        private TimeSpan _exitTime;
        public TimeSpan ExitTime
        {
            get { return _exitTime; }
            set { SetProperty(ref _exitTime, value); }
        }

        private TimeSpan _currentBalance;
        public TimeSpan CurrentBalance
        {
            get { return _currentBalance; }
            set { SetProperty(ref _currentBalance, value); }
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
