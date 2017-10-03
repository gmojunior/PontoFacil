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

        private int _notifyTime;
        public int NotifyTime
        {
            get { return _notifyTime; }
            set { SetProperty(ref _notifyTime, value); }
        }
        #endregion
    }
}