using PontoFacil.Models;
using PontoFacil.Services.Interfaces;

namespace PontoFacil.Services
{
    public class PlanningService : IPlanningService
    {
        #region Properties
        private IPersistencyService _persistencyService;
        #endregion

        #region Constructor
        public PlanningService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public Planning GetPlanning()
        {
            var profile = _persistencyService.getProfile();

            var planning = _persistencyService.getPlanning();
            planning.AccumulatedHoursValue = profile.AccumuletedHours;

            return planning;
        }

        public void Save(Planning planning)
        {
            _persistencyService.SavePlanning(planning);
        }
        #endregion
    }
}
