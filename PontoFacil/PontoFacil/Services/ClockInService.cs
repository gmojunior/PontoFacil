using PontoFacil.Models;
using PontoFacil.Repositories;
using System;

namespace PontoFacil.Services
{
    class ClockInService
    {
        private IRepository<ClockIn> Rep;
        private ClockIn clockIn;

        public ClockInService(IRepository<ClockIn> rep)
        {
            clockIn = new ClockIn();
            Rep = rep;
        }

        public void Register(DateTime date)
        {
            if (clockIn.IsOpen)
                EndCurrentDay(date);
            else
                StartNewDay(date);
        }

        private void StartNewDay(DateTime dt)
        {
            clockIn = new ClockIn();
            clockIn.Open(dt);

            //Rep add new day
        }

        private void EndCurrentDay(DateTime dt)
        {
            clockIn.Close(dt);
            Rep.SaveClockIn(clockIn);
        }
    }
}
