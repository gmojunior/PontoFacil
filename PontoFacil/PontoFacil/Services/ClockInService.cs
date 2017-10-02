using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;

namespace PontoFacil.Services
{
    public class ClockInService : IClockInService
    {
        #region Properties
        private ClockIn _clockIn;

        private IPersistencyService _persistencyService;

        #endregion

        #region Constructor
        public ClockInService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;

            _clockIn = _persistencyService.getClockInById(DateTime.Now.Date);
        }
        #endregion

        #region Methods
        public void Register(DateTime date)
        {
            if (_clockIn != null && _clockIn.IsOpen())
                EndCurrentDay(date);
            else
                StartNewDay(date);
        }

        private void StartNewDay(DateTime dt)
        {
            _clockIn = new ClockIn();

            _clockIn.Open(dt, _persistencyService.getProfile().LunchTime);
            _clockIn = _persistencyService.SaveClockIn(_clockIn);
        }

        private void EndCurrentDay(DateTime dt)
        {
            _clockIn.Close(dt);
            _persistencyService.SaveClockIn(_clockIn);
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            return _persistencyService.getClockInById(datetime);
        }

        #endregion
    }
}
