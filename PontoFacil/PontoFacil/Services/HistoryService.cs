using PontoFacil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoFacil.Services
{
    public class HistoryService : IHistoryService
    {
        #region Properties
        private List<ClockIn> _clockInList;
        private IPersistencyService _persistencyService;
        #endregion

        #region Constructor
        public HistoryService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;

            _clockInList = new List<ClockIn>();
        }
        #endregion

        #region Methods
        public List<ClockIn> GetMonthlyHistory()
        {
            _clockInList = _persistencyService.GetMonthlyHistory();
            return _clockInList;
        }

        public List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            _clockInList = _persistencyService.GetFreeHistory(startDate, endDate);
            return _clockInList;
        }

        public ClockIn AllowWaiver(ClockIn clockIn)
        {
            clockIn.AllowWaiver();
            return _persistencyService.SaveClockIn(clockIn);
        }
        #endregion
    }
}
