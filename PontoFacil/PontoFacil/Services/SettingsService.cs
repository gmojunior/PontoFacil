using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;

namespace PontoFacil.Services
{
    public class SettingsService : ISettingsService
    {
        #region Properties
        private IPersistencyService _persistencyService;
        #endregion

        #region Constructor
        public SettingsService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public Profile GetProfile()
        {
            return _persistencyService.getProfile();
        }

        public void Save(Profile profile)
        {
            _persistencyService.SaveProfile(profile);
        }

        public void UpdateProfileAcumulatedHours(TimeSpan overtimeHours)
        {
            Profile profile = _persistencyService.getProfile();
            profile.AccumuletedHours = profile.AccumuletedHours + overtimeHours;

            _persistencyService.SaveProfile(profile);
        }

        public TimeSpan GetProfileAccumulatedHours()
        {
            Profile profile = _persistencyService.getProfile();
            return profile.AccumuletedHours;
        }
        #endregion
    }
}
