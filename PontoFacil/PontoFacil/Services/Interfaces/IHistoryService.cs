using global::PontoFacil.Models;
using System;
using System.Collections.Generic;

namespace PontoFacil.Services
{
    public interface IHistoryService
    {
        List<ClockIn> GetMonthlyHistory();
        List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate);
        ClockIn AllowWaiver(ClockIn clockIn);
    }
}