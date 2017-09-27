using PontoFacil.Models;
using System;

namespace PontoFacil.Services
{
    class ClockInService
    {
        private ClockIn clockIn;

        private IPersistencyService PersistencyService;

        public ClockInService(IPersistencyService persistencyService)
        {
            PersistencyService = persistencyService;
        }

        public void Register(DateTime date)
        {
            ClockIn clockIn = PersistencyService.getClockInById(DateTime.Now.Date);

            if (clockIn != null)
                EndCurrentDay(date);
            else
                StartNewDay(date);
        }

        private void StartNewDay(DateTime dt)
        {
            clockIn = new ClockIn();
            clockIn.Open(dt);
            PersistencyService.SaveClockIn(clockIn);
        }

        private void EndCurrentDay(DateTime dt)
        {
            clockIn.Close(dt);
            PersistencyService.SaveClockIn(clockIn);
        }
    }
}
