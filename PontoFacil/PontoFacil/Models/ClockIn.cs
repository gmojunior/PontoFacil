using System;

namespace PontoFacil.Models
{
    class ClockIn
    {
        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            private set { _isOpen = value; }
        }

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
            _isOpen = false;
        }

        public void Close(DateTime dt)
        {
            _end = dt;
            _isOpen = false;
        }

        public ClockIn()
        {
            _isOpen = true;
        }
    }
}
