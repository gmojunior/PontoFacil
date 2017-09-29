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
            this._persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public Planning GetPlanning()
        {
            return this._persistencyService.getPlanning();
        }

        public void Save(Planning planning)
        {
            _persistencyService.SavePlanning(planning);
        }
        #endregion
    }
}
