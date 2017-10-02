using PontoFacil.Models;
using System;

namespace PontoFacil.Services.Interfaces
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
    }
}