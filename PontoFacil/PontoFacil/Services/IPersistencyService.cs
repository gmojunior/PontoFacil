using System;
using System.Collections.Generic;
using PontoFacil.Models;

namespace PontoFacil.Services
{
    public interface IPersistencyService
    {
        List<ClockIn> ClockInList { get; set; }
        Planning MyPlanning { get; set; }
        Profile MyProfile { get; set; }

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