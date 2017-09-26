using System.Collections.Generic;
using PontoFacil.Models;
using System.Threading.Tasks;
using System;

namespace PontoFacil.Services
{
    interface IPersistencyService
    {
        List<ClockIn> ClockInList { get; set; }
        Planning MyPlanning { get; set; }
        Profile MyProfile { get; set; }

        void Persist();
        void Restore();
        ClockIn getClockInById(DateTime datetime);
        void SaveClockIn(ClockIn clockIn);
        void SavePlanning(Planning planning);
        void SaveProfile(Profile profile);
    }
}