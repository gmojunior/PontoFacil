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
            return _persistencyService.getPlanning();
        }

        public void Save(Planning planning)
        {
            _persistencyService.SavePlanning(planning);
        }

        //TODO: Its necessary get the planning day instead of a all planning
        public void GetPlanningByDay()
        {
            var p = _persistencyService.getPlanning();
        }
        #endregion
    }
}
