using System;
using System.Collections.Generic;
using PontoFacil.Models;

namespace PontoFacil.Services
{
    public interface IPersistencyService
    {
        ClockIn getClockInById(DateTime datetime);
        Planning getPlanning();
        Profile getProfile();
        void Persist();
        void Restore();
        ClockIn SaveClockIn(ClockIn clockIn);
        Planning SavePlanning(Planning planning);
        Profile SaveProfile(Profile profile);
        List<ClockIn> GetMonthlyHistory();
        List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}