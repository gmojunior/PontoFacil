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

        private TimeSpan _workedHours;
        public TimeSpan WorkedHours
        {
            get { return _workedHours; }
            set { SetProperty(ref _workedHours, value); }
        }

        private TimeSpan _overtimeHours;
        public TimeSpan OvertimeHours
        {
            get { return _overtimeHours; }
            set { SetProperty(ref _overtimeHours, value); }
        }

        private TimeSpan _regularHours = new TimeSpan(8,0,0);
        
        private bool _isWaiver;
        public bool IsWaiver
        {
            get { return _isWaiver; }
            set { SetProperty(ref _isWaiver, value); }
        }

        public void Open(DateTime dt, int lunchTime)
        {
            Start = Convert.ToDateTime(dt.ToString("HH:mm:ss"));
            LunchTime = lunchTime;
            StartLunchTime = Convert.ToDateTime("12:00:00");
            EndLunchTime = lunchTime == 1 ? Convert.ToDateTime("13:00:00") : Convert.ToDateTime("14:00:00");
        }

        public void Close(DateTime dt)
        {
            End = dt;

            WorkedHours = End - Start.AddHours(LunchTime);
            OvertimeHours = WorkedHours - _regularHours;
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

        public void AllowWaiver()
        {
            this.IsWaiver = true;
            this.OvertimeHours = TimeSpan.Zero;
        }
    }
}