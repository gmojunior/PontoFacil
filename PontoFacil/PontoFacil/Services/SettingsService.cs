using PontoFacil.Models;

namespace PontoFacil.Services
{
    public class SettingsService : ISettingsService
    {
        #region Properties
        private static SettingsService settingsService;
        private IPersistencyService persistencyService;
        private Profile profile;
        #endregion

        public SettingsService(IPersistencyService persistencyService)
        {
            this.persistencyService = persistencyService;
            profile = this.persistencyService.getProfile();
        }

        public string GetName()
        {
            return profile.Name;
        }

        public Profile GetProfile()
        {
            return profile;
        }

        public void Save(Profile profile)
        {
            persistencyService.SaveProfile(profile);
        }
    }
}
