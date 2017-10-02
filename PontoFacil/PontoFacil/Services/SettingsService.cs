using PontoFacil.Models;
using PontoFacil.Services.Interfaces;

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
            this._persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public Profile GetProfile()
        {
            return this._persistencyService.getProfile();
        }

        public void Save(Profile profile)
        {
            _persistencyService.SaveProfile(profile);
        }
        #endregion
    }
}
