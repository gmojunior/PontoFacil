using System;

namespace PontoFacil.Models
{
    class ClockIn
    {
        private DateTime _start;
        private DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private DateTime _end;
        private DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }

        public void Open(DateTime dt)
        {
            _start = dt;
        }

        public void Close(DateTime dt)
        {
            _end = dt;
        }
    }
}
