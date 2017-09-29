using Prism.Mvvm;
using System;

namespace PontoFacil.Models
{
    public class ClockIn : BindableBase
    {
        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set { SetProperty(ref _start, value); }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set { SetProperty(ref _end, value); }
        }

        private int _lunchTime;
        public int LunchTime
        {
            get { return _lunchTime; }
            set { SetProperty(ref _lunchTime, value); }
        }

        private DateTime _startLunchTime;
        public DateTime StartLunchTime
        {
            get { return _startLunchTime; }
            set { SetProperty(ref _startLunchTime, value); }
        }

        private DateTime _endLunchTime;
        public DateTime EndLunchTime
        {
            get { return _endLunchTime; }
            set { SetProperty(ref _endLunchTime, value); }
        }

        private DateTime _regularHours;
        public DateTime RegularHours
        {
            get { return _regularHours; }
            set { SetProperty(ref _regularHours, value); }
        }

        private DateTime _overtimeHours;
        public DateTime OvertimeHours
        {
            get { return _overtimeHours; }
            set { SetProperty(ref _overtimeHours, value); }
        }

        public void Open(DateTime dt)
        {
            _start = dt;
        }

        public void Close(DateTime dt)
        {
            _end = dt;
        }

        public bool IsOpen()
        {
            return _start != null;
        }

        private DateTime? _id;
        public DateTime? Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
