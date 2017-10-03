using PontoFacil.Models;

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
        #endregion
    }
}
