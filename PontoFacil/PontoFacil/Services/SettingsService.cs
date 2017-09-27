using PontoFacil.Models;
using System;

namespace PontoFacil.Services
{
    class SettingsService : ISettingsService
    {
        #region Properties
        private static SettingsService settingsService;
        private IPersistencyService persistencyService;
        private Profile profile;
        #endregion

        #region Construcutor
        private SettingsService(IPersistencyService persistencyService)
        {
            this.persistencyService = persistencyService;
            profile = this.persistencyService.getProfile();
        }

        public static SettingsService getInstance(IPersistencyService persistencyService)
        {
            if (settingsService == null)
                settingsService = new SettingsService(persistencyService);
            return settingsService;
        }
        #endregion

        #region Methods
        public void RegisterName(string name)
        {
            profile.Name = name;
            persistencyService.SaveProfile(profile);
        }

        public string GetName()
        {
            return profile.Name;
        }

        public void RegisterDefaultStart(DateTime begin)
        {
            profile.DefaultBegin = begin;
            persistencyService.SaveProfile(profile);
        }

        public DateTime GetDefaultStart()
        {
            return profile.DefaultBegin;
        }

        public void RegisterDefaultFinish(DateTime finish)
        {
            profile.DefaultFinish = finish;
            persistencyService.SaveProfile(profile);
        }

        public DateTime GetDefaultFinish()
        {
            return profile.DefaultFinish;
        }

        public void RegisterLunchPeriod(DateTime lunchPeriod)
        {
            profile.LunchPeriod = lunchPeriod;
            persistencyService.SaveProfile(profile);
        }

        public DateTime GetLunchPeriod()
        {
            return profile.LunchPeriod;
        }

        public void RegisterAccumulatedHours(DateTime accumulatedHours)
        {
            profile.AccumulatedHours = accumulatedHours;
            persistencyService.SaveProfile(profile);
        }

        public DateTime GetrAccumulatedHours()
        {
            return profile.AccumulatedHours;
        }
        #endregion
    }
}
