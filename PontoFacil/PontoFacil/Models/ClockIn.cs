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
            private set { _start = value; }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            private set { _end = value; }
        }

        private int _lunchTime;
        public int LunchTime
        {
            get { return _lunchTime; }
            set { _lunchTime = value; }
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
