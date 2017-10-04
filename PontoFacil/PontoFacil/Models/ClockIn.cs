using Prism.Mvvm;
using System;

namespace PontoFacil.Models
{
    public class ClockIn : BindableBase
    {
        #region Properties
        private DateTime? _id;
        public DateTime? Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        private TimeSpan _regularHours;
        public TimeSpan RegularHours
        {
            get { return _regularHours; }
            set { SetProperty(ref _regularHours, value); }
        }

        private bool _isWaiver;
        public bool IsWaiver
        {
            get { return _isWaiver; }
            set { SetProperty(ref _isWaiver, value); }
        }

        private readonly DateTime MIDDAY = Convert.ToDateTime("12:00:00");
        private readonly DateTime ONE_PM = Convert.ToDateTime("13:00:00");
        private readonly DateTime TWO_PM = Convert.ToDateTime("14:00:00");
        #endregion

        #region Constructor
        public ClockIn()
        {
            RegularHours = new TimeSpan(8, 0, 0);
        }
        #endregion

        #region Methods
        public void Open(DateTime dt, int lunchTime)
        {
            Start = Convert.ToDateTime(dt.ToString("HH:mm:ss"));
            SetProperties(lunchTime);
        }
        
        public void Close(DateTime dt)
        {
            End = dt;

            WorkedHours = End - Start.AddHours(LunchTime);
            OvertimeHours = WorkedHours - _regularHours;
        }

        public bool IsOpen()
        {
            return (_start != null && DateTime.MinValue != _start) && (_end == null || DateTime.MinValue == _end );
        }

        public TimeSpan GetLunchTime()
        {
            return LunchTime == 1 ? new TimeSpan(1, 0, 0) : new TimeSpan(2, 0, 0);
        }

        public void AllowWaiver()
        {
            this.IsWaiver = true;
            this.OvertimeHours = TimeSpan.Zero;
        }

        private void SetProperties(int lunchTime)
        {
            LunchTime = lunchTime;
            StartLunchTime = MIDDAY;
            EndLunchTime = lunchTime == 1 ? ONE_PM : TWO_PM;
        }
        #endregion
    }
}