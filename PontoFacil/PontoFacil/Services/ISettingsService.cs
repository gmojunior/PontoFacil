using System;

namespace PontoFacil.Services
{
    interface ISettingsService
    {
        DateTime GetDefaultFinish();
        DateTime GetDefaultStart();
        DateTime GetLunchPeriod();
        string GetName();
        DateTime GetrAccumulatedHours();
        void RegisterAccumulatedHours(DateTime accumulatedHours);
        void RegisterDefaultFinish(DateTime finish);
        void RegisterDefaultStart(DateTime begin);
        void RegisterLunchPeriod(DateTime lunchPeriod);
        void RegisterName(string name);
    }
}